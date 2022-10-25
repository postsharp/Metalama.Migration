// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using PostSharp.Constraints;
using PostSharp.Extensibility;
using System.Text;
using System.Globalization;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Provides helper methods for work with <see cref="System.Reflection"/>.
    /// </summary>
#if !DEBUG
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
#endif
    public static class ReflectionHelper
    {
        private static readonly Dictionary<AssemblyPair, bool> areInternalsVisibleToCache = new Dictionary<AssemblyPair, bool>();

        internal static IReflectionHelperService GetReflectionHelperService()
        {
            return ServiceCache.Current.ReflectionHelperService;
        }

        private static MissingMemberException CreateMissingMemberException( Type declaringType, string memberName, string memberType )
        {
            return new MissingMemberException( string.Format(CultureInfo.InvariantCulture, "Missing {0}: {1}.{2}.", memberType, declaringType, memberName ) );
        }

        internal static MethodBase GetMethod( Type declaringType, string methodName, string methodSignature )
        {
            if ( methodName == ".cctor" )
            {
                foreach (
                    ConstructorInfo constructor in
                        declaringType.GetConstructors( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly ) )
                {
                    if ( (methodSignature == null && constructor.GetParameters().Length == 0) || constructor.ToString() == methodSignature )
                    {
                        return constructor;
                    }
                }
            }
            else
            {
                List<MethodBase> methods;

                if ( methodName == ".ctor" )
                {
                    methods = new List<MethodBase>( declaringType.GetConstructors( BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance ) );
                }
                else
                {
                    methods =
                        new List<MethodBase>(
                            declaringType.GetMethods( BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic ) );
                }

                foreach ( MethodBase method in methods )
                {
                    if ( methodName == method.Name )
                    {
                        if ( (methodSignature == null && method.GetParameters().Length == 0) || method.ToString() == methodSignature )
                        {
                            return method;
                        }
                    }
                }
            }

#if DEBUGGER_LOG
            if ( Debugger.IsLogging() )
            {
                Debugger.Log(
                    1,
                    "PostSharp",
                    string.Format(CultureInfo.InvariantCulture,
                        "PostSharp.Reflection.ReflectionHelper::GetMethod: Cannot find the method {{{0}}} on type {{{1}}}.{2}",
                        methodSignature,
                        declaringType.FullName,
                        Environment.NewLine ) );
            }
#endif

            throw new MissingMemberException( string.Format(CultureInfo.InvariantCulture, "Missing method '{0}' in type {1}.", methodSignature ?? methodName, declaringType ) );
        }

        private static string GetPropertyName( MethodInfo method )
        {
            if ( method == null )
            {
                return null;
            }

            int underscore = method.Name.IndexOf( '_' );
            return method.Name.Substring( underscore + 1 );
        }

        /// <ignore />
        [Internal]
        public static PropertyInfo GetProperty( Type declaringType, MethodInfo getter, MethodInfo setter )
        {
            return GetProperty( declaringType, getter, setter, false );
        }

        private static string GetShortMemberName( string fullName )
        {
            int period = fullName.LastIndexOf( '.' );
            if ( period > 0 )
            {
                return fullName.Substring( period + 1 );
            }
            else
            {
                return fullName;
            }
        }

        /// <ignore />
        [Internal]
        public static PropertyInfo GetProperty( Type declaringType, MethodInfo getter, MethodInfo setter, bool throwOnMissingMember )
        {
            string propertyName = GetPropertyName( getter ) ?? GetPropertyName( setter );

            if ( propertyName != null )
            {
                // The property was not stripped.
                foreach ( PropertyInfo property in
                    declaringType.GetProperties(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly ) )
                {
                    if ( GetShortMemberName( property.Name ) != propertyName )
                    {
                        continue;
                    }
                    if ( getter != null && !getter.Equals( property.GetGetMethod( true ) ) )
                    {
                        continue;
                    }
                    if ( setter != null && !setter.Equals( property.GetSetMethod( true ) ) )
                    {
                        continue;
                    }

                    return property;
                }
            }
            else
            {
#if LEGACY_MEMBER_INFO
                // The property was stripped. We have to return a placeholder.
                return new ObfuscatedPropertyInfo( declaringType, getter, setter );
#endif
            }

            if ( throwOnMissingMember )
            {
                throw CreateMissingMemberException( declaringType, propertyName, "property" );
            }
            else
            {
                return null;
            }
        }

        /// <ignore />
        [Internal]
        public static EventInfo GetEvent(
            Type declaringType, MethodInfo addMethod, MethodInfo removeMethod, MethodInfo raiseMethod )
        {
            string eventName = GetPropertyName( addMethod ) ?? GetPropertyName( removeMethod ) ?? GetPropertyName( raiseMethod );

            if ( eventName != null )
            {
                foreach (
                    EventInfo @event in
                        declaringType.GetEvents( BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public |
                                                 BindingFlags.NonPublic | BindingFlags.DeclaredOnly ) )
                {
                    if ( GetShortMemberName( @event.Name ) != eventName )
                    {
                        continue;
                    }
                    if ( addMethod != null && !addMethod.Equals( @event.GetAddMethod( true ) ) )
                    {
                        continue;
                    }
                    if ( removeMethod != null && !removeMethod.Equals( @event.GetRemoveMethod( true ) ) )
                    {
                        continue;
                    }
                    if ( raiseMethod != null && !raiseMethod.Equals( @event.GetRaiseMethod( true ) ) )
                    {
                        continue;
                    }

                    return @event;
                }
            }
            else
            {
#if LEGACY_MEMBER_INFO

                return new ObfuscatedEventInfo( declaringType, addMethod, removeMethod, raiseMethod );
#endif
            }

            throw CreateMissingMemberException( declaringType, eventName, "event" );
        }

        internal static PropertyInfo GetProperty( Type declaringType, string propertyName, string propertySignature )
        {
            // The property was not stripped.
            foreach ( PropertyInfo property in
                declaringType.GetProperties(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly ) )
            {
                if ( property.Name == propertyName &&
                     ((propertySignature == null && property.GetIndexParameters().Length == 0) || property.ToString() == propertySignature) )
                {
                    return property;
                }
            }

            throw CreateMissingMemberException( declaringType, propertyName, "property" );
        }

        /// <ignore />
        internal static FieldInfo GetField( Type declaringType, string fieldName )
        {
            return declaringType.GetField( fieldName, BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public );
        }

        /// <ignore />
        internal static LocationInfo GetLocation( Type declaringType, string locationName, string locationSignature, LocationKind locationKind )
        {
            const BindingFlags bindingAttr =
                BindingFlags.OptionalParamBinding | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance |
                BindingFlags.DeclaredOnly;

            switch ( locationKind )
            {
                case LocationKind.Field:
                    // First test if we have a field. It may have been transformed into a property.
                    FieldInfo field = declaringType.GetField( locationName, bindingAttr );
                    if ( field != null )
                    {
                        return new LocationInfo( field );
                    }
                    goto case LocationKind.Property;

                case LocationKind.Property:
                    PropertyInfo property = GetProperty( declaringType, locationName, locationSignature );
                    if ( property != null )
                    {
                        return new LocationInfo( property );
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(locationKind));
            }

            throw CreateMissingMemberException( declaringType, locationName, "property" );
        }

        /// <ignore />
        [Internal]
        public static LocationInfo GetLocation( Type declaringType, MethodInfo getter, MethodInfo setter )
        {
            PropertyInfo property = GetProperty( declaringType, getter, setter, false );
            if ( property != null )
            {
                return new LocationInfo( property );
            }
            else if ( getter != null || setter != null )
            {
                // The property has probably been obfuscated and/or suppressed.
                return new LocationInfo( getter, setter );
            }

            throw CreateMissingMemberException( declaringType, GetPropertyName( getter ) ?? GetPropertyName( setter ), "property" );
        }

        internal static string GetReflectionObjectKindName( object obj )
        {
            ReflectionObjectKind kind = GetReflectionObjectKind( obj );
            switch ( kind )
            {
                case ReflectionObjectKind.ReturnValue:
                    return "Return value of method";

                case ReflectionObjectKind.None:
                    return null;

                default:
                    return kind.ToString();
            }
        }

        internal static string GetReflectionObjectName( object obj )
        {
            MemberInfo member = obj as MemberInfo;

            switch ( GetReflectionObjectKind( obj ) )
            {
                case ReflectionObjectKind.Constructor:
                    return member.DeclaringType.FullName;

                case ReflectionObjectKind.Event:
                case ReflectionObjectKind.Field:
                case ReflectionObjectKind.Property:
                case ReflectionObjectKind.Method:
                    return member.DeclaringType.FullName + "." + member.Name;

                case ReflectionObjectKind.Type:
                    return ((Type) obj).FullName;

                case ReflectionObjectKind.Parameter:
                {
                    ParameterInfo parameterInfo = (ParameterInfo) obj;
                    return parameterInfo.Member.DeclaringType.FullName + "/" + parameterInfo.Member.Name + "@" + parameterInfo.Name;
                }

                case ReflectionObjectKind.ReturnValue:
                {
                    ParameterInfo parameterInfo = (ParameterInfo) obj;
                    return parameterInfo.Member.DeclaringType.FullName + "/" + parameterInfo.Member.Name + "@" + "ReturnValue";
                }

                default:
                    return null;
            }
        }

        /// <summary>
        /// Determines whether a given <see cref="MemberInfo"/> is available in the target framework
        /// of the current project.
        /// </summary>
        /// <param name="memberInfo">A declaration that necessarily exists in the build-time framework.</param>
        /// <returns></returns>
        public static bool IsAvailableInTargetFramework( this MemberInfo memberInfo )
        {
            return ServiceCache.Current.ReflectionHelperService.IsAvailableInTargetFramework( memberInfo );
        }

        /// <summary>
        /// Determines whether a given <see cref="Type"/> is available in the target framework
        /// of the current project.
        /// </summary>
        /// <param name="type">A declaration that necessarily exists in the build-time framework.</param>
        /// <returns></returns>
        public static bool IsAvailableInTargetFramework( this Type type )
        {
            return ServiceCache.Current.ReflectionHelperService.IsAvailableInTargetFramework( type );
        }

        internal static bool IsOnlyFamilyVisible( MemberInfo member )
        {
            MethodBase method;
            FieldInfo field;
            Type type;

            if ( (method = member as MethodBase) != null )
            {
                return IsOnlyFamilyVisible( method );
            }
            else if ( (field = member as FieldInfo) != null )
            {
                return IsOnlyFamilyVisible( field );
            }
            else if ( (type = member.AsType()) != null )
            {
                return IsOnlyFamilyVisible( type );
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        internal static bool IsOnlyFamilyVisible( FieldInfo field )
        {
            switch ( field.Attributes & FieldAttributes.FieldAccessMask )
            {
                case FieldAttributes.Private:
                case FieldAttributes.Family:
                    return true;
                default:
                    return IsOnlyFamilyVisible( field.DeclaringType );
            }
        }

        internal static bool IsOnlyFamilyVisible( MethodBase method )
        {
            switch ( method.Attributes & MethodAttributes.MemberAccessMask )
            {
                case MethodAttributes.Private:
                case MethodAttributes.Family:
                    return true;
                default:
                    return IsOnlyFamilyVisible( method.DeclaringType );
            }
        }

        internal static bool IsOnlyFamilyVisible( Type type )
        {
            switch ( type.GetAttributes() & TypeAttributes.VisibilityMask )
            {
                case TypeAttributes.NestedPrivate:
                case TypeAttributes.NestedFamily:
                    return true;

                case TypeAttributes.NestedAssembly:
                case TypeAttributes.NestedFamORAssem:
                case TypeAttributes.NestedPublic:
                    return IsOnlyFamilyVisible( type.DeclaringType );

                default:
                    return false;
            }
        }

        internal static bool IsExported( MemberInfo member )
        {
            MethodBase method;
            FieldInfo field;
            Type type;
            PropertyInfo property;
            EventInfo @event;

            if ( (method = member as MethodBase) != null )
            {
                return IsExported( method );
            }
            else if ( (field = member as FieldInfo) != null )
            {
                return IsExported( field );
            }
            else if ( (type = member.AsType()) != null )
            {
                return IsExported( type );
            }
            else if ( (@event = member as EventInfo) != null )
            {
                return IsExported( @event );
            }
            else if ( (property = member as PropertyInfo) != null )
            {
                return IsExported( property );
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(member));
            }
        }

        internal static bool IsExported( FieldInfo field )
        {
            switch ( field.Attributes & FieldAttributes.FieldAccessMask )
            {
                case FieldAttributes.Public:
                case FieldAttributes.Family:
                case FieldAttributes.FamORAssem:
                    return IsExported( field.DeclaringType );

                default:
                    return false;
            }
        }

        internal static bool IsExported( MethodBase method )
        {
            switch ( method.Attributes & MethodAttributes.MemberAccessMask )
            {
                case MethodAttributes.Family:
                case MethodAttributes.Public:
                case MethodAttributes.FamORAssem:
                    return IsExported( method.DeclaringType );

                default:
                    return false;
            }
        }

        internal static bool IsExported( PropertyInfo property )
        {
            foreach ( MethodInfo method in property.GetAccessors( true ) )
            {
                if ( IsExported( method ) )
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool IsExported( EventInfo @event )
        {
            MethodInfo addMethod = @event.GetAddMethod( true );
            if ( addMethod != null && IsExported( addMethod ) )
            {
                return true;
            }

            MethodInfo removeMethod = @event.GetRemoveMethod( true );
            if ( removeMethod != null && IsExported( removeMethod ) )
            {
                return true;
            }

            return false;
        }

        internal static bool IsExported( Type type )
        {
            if ( type.HasElementType )
            {
                return IsExported( type.GetElementType() );
            }

            switch ( type.GetAttributes() & TypeAttributes.VisibilityMask )
            {
                case TypeAttributes.NestedAssembly:
                case TypeAttributes.NestedFamANDAssem:
                case TypeAttributes.NestedPrivate:
                    return false;

                case TypeAttributes.NestedFamily:
                case TypeAttributes.NestedFamORAssem:
                case TypeAttributes.NestedPublic:
                    return IsExported( type.DeclaringType );

                case TypeAttributes.NotPublic:
                    return false;

                case TypeAttributes.Public:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException( nameof(type));
            }
        }

        internal static bool IsPublic( Type type )
        {
            if ( type.HasElementType )
            {
                return IsExported( type.GetElementType() );
            }

            switch ( type.GetAttributes() & TypeAttributes.VisibilityMask )
            {
                case TypeAttributes.NestedAssembly:
                case TypeAttributes.NestedFamANDAssem:
                case TypeAttributes.NestedPrivate:
                case TypeAttributes.NestedFamily:
                case TypeAttributes.NestedFamORAssem:
                    return false;

                case TypeAttributes.NestedPublic:
                    return IsPublic( type.DeclaringType );

                case TypeAttributes.NotPublic:
                    return false;

                case TypeAttributes.Public:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException( nameof(type));
            }
        }

        internal static Assembly GetDeclaringAssembly( object obj )
        {
            Assembly assembly = obj as Assembly;
            if ( assembly != null )
            {
                return assembly;
            }

            Type declaringType = GetDeclaringType( obj );
            if ( declaringType != null )
            {
                return declaringType.GetAssembly();
            }

            return null;
        }

        internal static Type GetDeclaringType( object obj )
        {
            Type declaringType;
            MemberInfo memberInfo;
            GetMemberInfo( obj, out declaringType, out memberInfo );
            return declaringType;
        }

        internal static void GetMemberInfo( object obj, out Type declaringType, out MemberInfo declaringMember )
        {
            ParameterInfo parameter;
            LocationInfo location = obj as LocationInfo;

            if ( location != null )
            {
                obj = location.UnderlyingReflectionObject;
            }

            if ( (declaringType = obj as Type) != null )
            {
                if ( declaringType.IsGenericParameter )
                {
                    declaringType = declaringType.DeclaringType;
                }
                declaringMember = null;
            }
            else if ( (declaringMember = obj as MemberInfo) != null )
            {
                declaringType = declaringMember.DeclaringType;
            }
            else if ( (parameter = obj as ParameterInfo) != null )
            {
                declaringType = parameter.Member.DeclaringType;
                declaringMember = parameter.Member;
            }
            else
            {
                declaringType = null;
                declaringMember = null;
            }
        }

        internal static Type GetNestingType( Type type )
        {
            Type cursor;
            for ( cursor = type; cursor.DeclaringType != null; cursor = cursor.DeclaringType )
            {
            }
            return cursor;
        }

        internal static TypeCode GetTypeCode( Type type )
        {
            ITypeWrapper typeWrapper = type as ITypeWrapper;
            if ( typeWrapper != null )
            {
                return typeWrapper.GetTypeCode();
            }
            else
            {
                return type.GetTypeCode();
            }
        }

        internal static bool SafeIsAssignableFrom( Type baseType, Type derivedType )
        {
            ITypeWrapper derivedTypeWrapper = baseType as ITypeWrapper;
            ITypeWrapper baseTypeWrapper = derivedType as ITypeWrapper;

            if ( derivedTypeWrapper != null )
            {
                return derivedTypeWrapper.IsAssignableFrom( derivedType );
            }
            else if ( baseTypeWrapper != null )
            {
                return baseTypeWrapper.IsAssignableTo( baseType );
            }
            else
            {
                return baseType.IsAssignableFrom( derivedType );
            }
        }

        private static ReflectionObjectKind GetReflectionObjectKind( object obj )
        {
            ParameterInfo parameterInfo;

            if ( obj is Type )
            {
                return ReflectionObjectKind.Type;
            }
            else if ( obj is ConstructorInfo )
            {
                return ReflectionObjectKind.Constructor;
            }
            else if ( obj is MethodInfo )
            {
                return ReflectionObjectKind.Method;
            }
            else if ( obj is PropertyInfo )
            {
                return ReflectionObjectKind.Property;
            }
            else if ( obj is EventInfo )
            {
                return ReflectionObjectKind.Event;
            }
            else if ( obj is FieldInfo )
            {
                return ReflectionObjectKind.Field;
            }
            else if ( (parameterInfo = obj as ParameterInfo) != null )
            {
                if ( parameterInfo.Position == -1 )
                {
                    return ReflectionObjectKind.ReturnValue;
                }
                else
                {
                    return ReflectionObjectKind.Parameter;
                }
            }
            else
            {
                return ReflectionObjectKind.None;
            }
        }

        internal static void VisitTypeElements( Type type, Action<Type> visitor )
        {
            visitor( type );

            if ( type.HasElementType )
            {
                VisitTypeElements( type.GetElementType(), visitor );
            }
            else if ( type.IsGenericType() && !type.IsGenericTypeDefinition() )
            {
                VisitTypeElements( type.GetGenericTypeDefinition(), visitor );
                foreach ( Type genericArgument in type.GetGenericArguments() )
                {
                    VisitTypeElements( genericArgument, visitor );
                }
            }
        }

      
        internal static DeclarationIdentifier GetDeclarationIdentifier(MemberInfo member)
        {
            return GetReflectionHelperService().GetDeclarationIdentifier( member );

        }

        /// <summary>
        /// Determines whether a <see cref="MemberInfo"/> is compiler-generated.
        /// </summary>
        /// <param name="member">A <see cref="MemberInfo"/>.</param>
        /// <returns><c>true</c> if <paramref name="member"/> is compiler-generated, <c>false</c> if it is hand-coded.</returns>
        public static bool IsCompilerGenerated( this MemberInfo member )
        {
            if ( member == null )
                throw new ArgumentNullException(nameof(member));

            return GetReflectionHelperService().IsCompilerGenerated(member);
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> is compiler-generated.
        /// </summary>
        /// <param name="type">A <see cref="Type"/>.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is compiler-generated, <c>false</c> if it is hand-coded.</returns>
        public static bool IsCompilerGenerated(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return GetReflectionHelperService().IsCompilerGenerated(type);
        }

        /// <summary>
        /// Gets the <see cref="SemanticInfo"/> for a given member.
        /// </summary>
        /// <param name="member">A member.</param>
        /// <returns>The <see cref="SemanticInfo"/> for <paramref name="member"/>.</returns>
        public static SemanticInfo GetSemanticInfo(this MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException(nameof(member));

            return GetReflectionHelperService().GetSemanticInfo(member);
        }

        /// <summary>
        /// Gets the <see cref="SemanticInfo"/> for a given type.
        /// </summary>
        /// <param name="type">A type.</param>
        /// <returns>The <see cref="SemanticInfo"/> for <paramref name="type"/>.</returns>
        public static SemanticInfo GetSemanticInfo(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return GetReflectionHelperService().GetSemanticInfo(type);
        }

        /// <summary>
        /// Determines whether the internals of a given assembly are visible to the current project.
        /// </summary>
        /// <param name="definingAssembly">The assembly containing the internal declaration.</param>
        /// <returns><c>true</c> if <paramref name="definingAssembly"/> equals the assembly being processed or if <paramref name="definingAssembly"/> contains an <see cref="InternalsVisibleToAttribute"/> attribute
        /// for the assembly being processed, otherwise <c>false</c>.</returns>
        public static bool AreInternalsVisibleToCurrentProject( this Assembly definingAssembly )
        {
            return definingAssembly.AreInternalsVisibleTo( PostSharpEnvironment.Current.CurrentProject.TargetAssembly );
        }

        /// <summary>
        /// Determines whether the <see cref="InternalsVisibleToAttribute"/> attribute relationship exists between two assemblies.
        /// </summary>
        /// <param name="definingAssembly">The assembly defining the <see cref="InternalsVisibleToAttribute"/> attribute.</param>
        /// <param name="referencingAssembly">The assembly referenced by the <see cref="InternalsVisibleToAttribute"/> attribute.</param>
        /// <returns><c>true</c> if <paramref name="definingAssembly"/> equals <paramref name="referencingAssembly"/> or if <paramref name="definingAssembly"/> contains an <see cref="InternalsVisibleToAttribute"/> attribute
        /// for <paramref name="referencingAssembly"/>, otherwise <c>false</c>.</returns>
        public static bool AreInternalsVisibleTo(this Assembly definingAssembly, Assembly referencingAssembly )
        {
            if ( definingAssembly == null )
                throw new ArgumentNullException(nameof(definingAssembly));

            if ( referencingAssembly == null )
                throw new ArgumentNullException(nameof(referencingAssembly));

            if ( definingAssembly == referencingAssembly )
                return true;


            bool result;
            AssemblyPair cacheKey = new AssemblyPair(definingAssembly, referencingAssembly);
            if ( !areInternalsVisibleToCache.TryGetValue( cacheKey, out result ) )
            {
                lock ( areInternalsVisibleToCache )
                {
                    if ( !areInternalsVisibleToCache.TryGetValue( cacheKey, out result ) )
                    {
                        object[] attributes = definingAssembly.GetCustomAttributes( typeof(InternalsVisibleToAttribute), false );

                        foreach (InternalsVisibleToAttribute attribute in attributes)
                        {
                            AssemblyName assemblyName;

                            try
                            {
                                assemblyName = new AssemblyName( attribute.AssemblyName );
                            }
#if DEBUG
                            finally
                            {
                            }
#else
                            catch
                            {
                                continue;
                            }
#endif

                            if ( GetReflectionHelperService().AssemblyReferenceMatchesDefinition( assemblyName, referencingAssembly ) )
                            {
                                result = true;
                                break;
                            }

                        }

                        areInternalsVisibleToCache.Add( cacheKey, result );
                    }
                    
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a properly-escaped assembly-qualified type name from its components.
        /// </summary>
        /// <param name="typeName">The type name.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <returns>A string of the form <code>TypeName, AssemblyName</code>, where commas in <paramref name="typeName"/> have been properly escaped.</returns>
        public static string GetAssemblyQualifiedTypeName(string typeName, string assemblyName)
        {
            if (typeName == null)
            {
                throw new ArgumentNullException(nameof(assemblyName));
            }

            if (typeName == null)
            {
                throw new ArgumentNullException(nameof(assemblyName));
            }

            return typeName.Replace(",", "\\,") + ", " + assemblyName;
        }

        /// <summary>
        /// Parses an escaped assembly-qualified type name into its components.
        /// </summary>
        /// <param name="assemblyQualifiedTypeName">The escaped assembly-qualified type name.</param>
        /// <param name="typeName">The type name.</param>
        /// <param name="assemblyName">The assembly name.</param>
        public static void ParseAssemblyQualifiedTypeName(string assemblyQualifiedTypeName, out string typeName, out string assemblyName)
        {
            bool isEscaped;
            int indexOfComma = IndexOfUnescapedComma(assemblyQualifiedTypeName, out isEscaped);
            if (indexOfComma >= 0)
            {
                typeName = assemblyQualifiedTypeName.Substring(0, indexOfComma).Trim();

                assemblyName = assemblyQualifiedTypeName.Substring(indexOfComma + 1).Trim();
            }
            else
            {
                typeName = assemblyQualifiedTypeName.Trim();
                assemblyName = null;
            }

            if (isEscaped)
            {
                typeName = Unescape(typeName);
            }
        }

        internal static bool CanInternalsBeReferenced( this Assembly assembly )
        {
            // This implementation is a simplification. Basically, internals of system assemblies cannot be referenced because
            // we are not able to map/bind the internal types (there is no type forwarder for internal types).

            // The right thing to do would be to check if the assembly has a type index, but I'm not sure of this approach neither (we sometimes work without a type index).

            string assemblyName = assembly.GetName().Name;

            return !(assemblyName.Equals( "mscorlib", StringComparison.OrdinalIgnoreCase ) ||
                    assemblyName.Equals( "netstandard", StringComparison.OrdinalIgnoreCase ) ||
                    assemblyName.Equals( "system", StringComparison.OrdinalIgnoreCase ) ||
                    assemblyName.StartsWith( "system.", StringComparison.OrdinalIgnoreCase ));
        }

        private static string Unescape(string input)
        {
            StringBuilder valueBuilder = new StringBuilder(input.Length);
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    i++;
                    if (i == input.Length)
                        break;
                }
                valueBuilder.Append(input[i]);
            }
            return valueBuilder.ToString();
        }

        private static int IndexOfUnescapedComma(string typeName, out bool isEscaped)
        {
            isEscaped = false;
            int indexOfComma = 0;
            while ((indexOfComma = typeName.IndexOf(',', indexOfComma)) >= 0)
            {
                if (indexOfComma > 0)
                {
                    if (typeName[indexOfComma - 1] == '\\')
                    {
                        isEscaped = true;
                        indexOfComma++;
                    }
                    else
                    {
                        return indexOfComma;
                    }
                }
            }

            return -1;
        }

       

        struct AssemblyPair : IEquatable<AssemblyPair>
        {

            private readonly Assembly definingAssembly;
            private readonly Assembly referencingAssembly;


            public AssemblyPair( Assembly definingAssembly, Assembly referencingAssembly )
            {
                this.definingAssembly = definingAssembly;
                this.referencingAssembly = referencingAssembly;
            }

            public bool Equals( AssemblyPair other )
            {
                return Equals( this.definingAssembly, other.definingAssembly ) && Equals( this.referencingAssembly, other.referencingAssembly );
            }

            public override bool Equals( object obj )
            {
                if ( ReferenceEquals( null, obj ) )
                {
                    return false;
                }
                return obj is AssemblyPair && this.Equals( (AssemblyPair) obj );
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((this.definingAssembly != null ? this.definingAssembly.GetHashCode() : 0)*397) ^ (this.referencingAssembly != null ? this.referencingAssembly.GetHashCode() : 0);
                }
            }
        }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;
using System;
using System.Reflection;
using PostSharp.Extensibility;
#pragma warning disable CA1801 // Parameters kept for backwards compatibility.

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Set of static methods providing broader access to assembly metadata than
    ///   the <c>System.Reflection</c> namespace. These methods are only
    ///   available at build time.
    /// </summary>
    /// <remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
    /// </remarks>    
    public static class ReflectionSearch
    {
        /// <summary>
        ///   Gets all custom attributes of a given type in the assembly being currently processed.
        /// </summary>
        /// <param name = "customAttributeType"><see cref = "Type" /> of the custom attribute.</param>
        /// <returns>The set of all custom attributes of type <paramref name = "customAttributeType" />
        ///   defined in  the assembly being currently processed.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='annotationRepository']/*" />
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType )
        {
            return GetCustomAttributesOfType( customAttributeType, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets all custom attributes of a given type in the assembly being currently processed and specifies 
        ///   additional options.
        /// </summary>
        /// <param name = "customAttributeType"><see cref = "Type" /> of the custom attribute.</param>
        /// <param name = "options">Either <see cref = "ReflectionSearchOptions.IncludeDerivedTypes" /> or <see cref="ReflectionSearchOptions.None"/>.</param>
        /// <returns>The set of all custom attributes of type <paramref name = "customAttributeType" /> (or any type derived
        ///   from <paramref name = "customAttributeType" />, if the option <see cref = "ReflectionSearchOptions.IncludeDerivedTypes" /> 
        ///   is <c>true</c>) defined in  the assembly being currently processed.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='annotationRepository']/*" />
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.AnnotationRepositoryService.GetCustomAttributesOfType( customAttributeType, options );
        }

        /// <summary>
        ///   Gets all custom attributes on a given element of code, including those who have been added indirectly, for
        ///   instance through <see cref = "MulticastAttribute" />.
        /// </summary>
        /// <param name = "target">Element of code (<see cref = "Type" />, <see cref = "MethodInfo" />, ...) whose
        ///   custom attributes are requested.</param>
        /// <returns>The set of all custom attributes added, directly or indirectly, to <paramref name = "target" />.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='annotationRepository']/*" />
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target )
        {
            return GetCustomAttributesOnTarget( target, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets all custom attributes on a given element of code, including those who have been added indirectly, for
        ///   instance through <see cref = "MulticastAttribute" />.
        /// </summary>
        /// <param name = "target">Element of code (<see cref = "Type" />, <see cref = "MethodInfo" />, ...) whose
        ///   custom attributes are requested.</param>
        /// <param name = "options">This parameter has no effect and is kept only for backwards compatibility.</param>
        /// <returns>The set of all custom attributes added, directly or indirectly, to <paramref name = "target" />.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='annotationRepository']/*" />
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.AnnotationRepositoryService.GetCustomAttributesOnTarget( target );
        }

        /// <summary>
        ///   Gets all custom attributes of a given type on a given element of code, including those who have been added indirectly, for
        ///   instance through <see cref = "MulticastAttribute" /> and specifies additional options.
        /// </summary>
        /// <typeparam name="T">Type of the custom attribute.</typeparam>
        /// <param name = "target">Element of code (<see cref = "Type" />, <see cref = "MethodInfo" />, ...) whose
        ///   custom attributes are requested.</param>
        /// <param name = "options"><see cref = "ReflectionSearchOptions.IncludeDerivedTypes" /> or <see cref="ReflectionSearchOptions.None"/>.</param>
        /// <returns>The set of all custom attributes added, directly or indirectly, to <paramref name = "target" />.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='annotationRepository']/*" />
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static IList<T> GetCustomAttributesOnTarget<T>(object target, ReflectionSearchOptions options = ReflectionSearchOptions.IncludeDerivedTypes) where T : Attribute
        {
            List<T> list = new List<T>();
            foreach ( CustomAttributeInstance customAttributeInstance in GetCustomAttributesOnTarget( target, ReflectionSearchOptions.None ) )
            {
                Type attributeType = customAttributeInstance.Construction.Constructor.DeclaringType;
                if ( ((options & ReflectionSearchOptions.IncludeDerivedTypes) != 0 && typeof(T).IsAssignableFrom( attributeType ))
                     || typeof(T) == attributeType )
                {
                    list.Add( (T) customAttributeInstance.Attribute );
                }
            }

            return list;
        }

        /// <summary>
        /// Determines whether a declaration has a custom attribute of a given type, including those who have been added indirectly, for
        ///   instance through <see cref = "MulticastAttribute" />.
        /// </summary>
        /// <param name = "target">Element of code (<see cref = "Type" />, <see cref = "MethodInfo" />, ...) whose
        ///   custom attributes are requested.</param>
        /// <param name="type">The type of custom attributes.</param>
        /// <param name="inherit"><c>true</c> to consider custom attributes derived from <paramref name="type"/>, <c>false</c> to consider
        /// only custom attributes strictly of type <paramref name="type"/>.</param>
        /// <returns>True if <paramref name="type"/> has a custom attribute of type <paramref name="type"/>, otherwise <c>false</c>.</returns>
        public static bool HasCustomAttribute(object target, Type type, bool inherit = false )
        {
            foreach ( CustomAttributeInstance attribute in GetCustomAttributesOnTarget(target) )
            {
                if ( inherit )
                {
                    if ( type.IsAssignableFrom(  attribute.Construction.Constructor.DeclaringType ))
                        return true;
                }
                else
                {
                    if ( attribute.Construction.Constructor.DeclaringType == type )
                        return true;
                }
                
            }

            return false;
        }

        /// <summary>
        ///   Gets all declarations (<see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />) used
        ///   by the body of a given method or constructor.
        /// </summary>
        /// <param name = "method">A <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />.</param>
        /// <returns>An array of <see cref = "MethodUsageCodeReference" /> containing one
        ///   item for each declaration used by the body of <paramref name = "method" />.</returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method )
        {
            return GetDeclarationsUsedByMethod( method, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets all declarations (<see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />) used
        ///   by the body of a given method or constructor and specifies additional options.
        /// </summary>
        /// <param name = "method">A <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />.</param>
        /// <param name = "options">This parameter has no effect and is kept only for backwards compatibility.</param>
        /// <returns>An array of <see cref = "MethodUsageCodeReference" /> containing one
        ///   item for each declaration used by the body of <paramref name = "method" />.
        /// </returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.IndexUsageService.GetMembersUsedByMethod( method );
        }

        /// <summary>
        ///   Gets the set of methods and constructors whose body references a given (<see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />).
        /// </summary>
        /// <param name = "declaration">The <see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />
        ///   whose references are requested.</param>
        /// <returns>An array of <see cref = "MethodUsageCodeReference" /> containing one
        ///   item for each method or constructor whose body references <paramref name = "declaration" />.
        /// </returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration )
        {
            return GetMethodsUsingDeclaration( declaration, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets the set of methods and constructors whose body references a given (<see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />).
        /// </summary>
        /// <param name = "declaration">The <see cref = "Type" />,
        ///   <see cref = "FieldInfo" />, <see cref = "MethodInfo" /> or <see cref = "ConstructorInfo" />
        ///   whose references are requested.</param>
        /// <param name = "options">This parameter has no effect and is kept only for backwards compatibility.</param>
         /// <returns>An array of <see cref = "MethodUsageCodeReference" /> containing one
        ///   item for each method or constructor whose body references <paramref name = "declaration" />.
        /// </returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.IndexUsageService.GetMethodsUsingMember( declaration );
        }

        /// <summary>
        ///   Gets the set of types derived from a given class or implementing a given interface.
        /// </summary>
        /// <param name = "baseType">A class or interface.</param>
        /// <returns>The set of types derived from or implementing <paramref name = "baseType" />.</returns>
        /// <remarks>
        ///   <para>This method returns only types defined in the assembly being currently processed.</para>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType )
        {
            return GetDerivedTypes( baseType, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets the set of types derived from a given class or implementing a given interface.
        ///   and specifies additional options.
        /// </summary>
        /// <param name = "baseType">A class or interface.</param>
        /// <param name = "options">Either <see cref="ReflectionSearchOptions.IncludeTypeElement"/> (partial type match), or 
        /// <see cref="ReflectionSearchOptions.IncludeDerivedTypes"/> (deep search), but not both, or <see cref="ReflectionSearchOptions.None"/>.</param>
        /// <returns>The set of types derived from or implementing <paramref name = "baseType" />.</returns>
        /// <remarks>
        ///   <para>This method returns only types defined in the assembly being currently processed.</para>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.TypeHierarchyService.GetDerivedTypes( baseType, options );
        }

        /// <summary>
        ///   Gets all members (<see cref = "FieldInfo" />, <see cref = "PropertyInfo" />, or
        ///   <see cref = "ParameterInfo" />) of the assembly being processed of a given type.
        /// </summary>
        /// <param name = "memberType">Member type.</param>
        /// <returns>The set of all members of type <paramref name = "memberType" /> in the assembly being processed</returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType )
        {
            return GetMembersOfType( memberType, ReflectionSearchOptions.None );
        }

        /// <summary>
        ///   Gets all members (<see cref = "FieldInfo" />, <see cref = "PropertyInfo" />, or
        ///   <see cref = "ParameterInfo" />) of the assembly being processed of a given type and specifies additional options.
        /// </summary>
        /// <param name = "memberType">Member type.</param>
        /// <param name = "options">Either <see cref="ReflectionSearchOptions.IncludeTypeElement"/> or <see cref="ReflectionSearchOptions.None"/>.</param>
        /// <returns>The set of all members of type <paramref name = "memberType" /> in the assembly being processed</returns>
        /// <remarks>
        /// <include file = "../Documentation.xml" path = "/documentation/section[@name='buildTime']/*" />
        /// </remarks>
        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType, ReflectionSearchOptions options )
        {
            return ServiceCache.Current.MemberTypeIndexService.GetMembersOfType( memberType, options );
        }
    }
}

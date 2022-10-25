using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Provides helper methods for work with <see cref="System.Reflection"/>.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public static class ReflectionHelper
    {
        /// <ignore />
        public static PropertyInfo GetProperty( Type declaringType, MethodInfo getter, MethodInfo setter )
        {
            throw new NotImplementedException();
        }

        /// <ignore />
        public static PropertyInfo GetProperty( Type declaringType, MethodInfo getter, MethodInfo setter, bool throwOnMissingMember )
        {
            throw new NotImplementedException();
        }

        /// <ignore />
        public static EventInfo GetEvent( Type declaringType, MethodInfo addMethod, MethodInfo removeMethod, MethodInfo raiseMethod )
        {
            throw new NotImplementedException();
        }

        /// <ignore />
        public static LocationInfo GetLocation( Type declaringType, MethodInfo getter, MethodInfo setter )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a given <see cref="MemberInfo"/> is available in the target framework
        /// of the current project.
        /// </summary>
        /// <param name="memberInfo">A declaration that necessarily exists in the build-time framework.</param>
        /// <returns></returns>
        public static bool IsAvailableInTargetFramework( this MemberInfo memberInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a given <see cref="Type"/> is available in the target framework
        /// of the current project.
        /// </summary>
        /// <param name="type">A declaration that necessarily exists in the build-time framework.</param>
        /// <returns></returns>
        public static bool IsAvailableInTargetFramework( this Type type )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a <see cref="MemberInfo"/> is compiler-generated.
        /// </summary>
        /// <param name="member">A <see cref="MemberInfo"/>.</param>
        /// <returns><c>true</c> if <paramref name="member"/> is compiler-generated, <c>false</c> if it is hand-coded.</returns>
        public static bool IsCompilerGenerated( this MemberInfo member )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> is compiler-generated.
        /// </summary>
        /// <param name="type">A <see cref="Type"/>.</param>
        /// <returns><c>true</c> if <paramref name="type"/> is compiler-generated, <c>false</c> if it is hand-coded.</returns>
        public static bool IsCompilerGenerated( this Type type )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="SemanticInfo"/> for a given member.
        /// </summary>
        /// <param name="member">A member.</param>
        /// <returns>The <see cref="SemanticInfo"/> for <paramref name="member"/>.</returns>
        public static SemanticInfo GetSemanticInfo( this MemberInfo member )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="SemanticInfo"/> for a given type.
        /// </summary>
        /// <param name="type">A type.</param>
        /// <returns>The <see cref="SemanticInfo"/> for <paramref name="type"/>.</returns>
        public static SemanticInfo GetSemanticInfo( this Type type )
        {
            throw new NotImplementedException();
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
        public static bool AreInternalsVisibleTo( this Assembly definingAssembly, Assembly referencingAssembly )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a properly-escaped assembly-qualified type name from its components.
        /// </summary>
        /// <param name="typeName">The type name.</param>
        /// <param name="assemblyName">The assembly name.</param>
        /// <returns>A string of the form <code>TypeName, AssemblyName</code>, where commas in <paramref name="typeName"/> have been properly escaped.</returns>
        public static string GetAssemblyQualifiedTypeName( string typeName, string assemblyName )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Parses an escaped assembly-qualified type name into its components.
        /// </summary>
        /// <param name="assemblyQualifiedTypeName">The escaped assembly-qualified type name.</param>
        /// <param name="typeName">The type name.</param>
        /// <param name="assemblyName">The assembly name.</param>
        public static void ParseAssemblyQualifiedTypeName( string assemblyQualifiedTypeName, out string typeName, out string assemblyName )
        {
            throw new NotImplementedException();
        }
    }
}
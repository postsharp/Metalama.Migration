using System;
using System.Collections.Generic;
using System.Reflection;

#pragma warning disable CA1801 // Parameters kept for backwards compatibility.

namespace PostSharp.Reflection
{
    public static class ReflectionSearch
    {
        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType )
        {
            return GetCustomAttributesOfType( customAttributeType, ReflectionSearchOptions.None );
        }

        public static CustomAttributeInstance[] GetCustomAttributesOfType( Type customAttributeType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target )
        {
            return GetCustomAttributesOnTarget( target, ReflectionSearchOptions.None );
        }

        public static CustomAttributeInstance[] GetCustomAttributesOnTarget( object target, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        public static IList<T> GetCustomAttributesOnTarget<T>( object target, ReflectionSearchOptions options = ReflectionSearchOptions.IncludeDerivedTypes )
            where T : Attribute
        {
            throw new NotImplementedException();
        }

        public static bool HasCustomAttribute( object target, Type type, bool inherit = false )
        {
            throw new NotImplementedException();
        }

        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method )
        {
            return GetDeclarationsUsedByMethod( method, ReflectionSearchOptions.None );
        }

        public static MethodUsageCodeReference[] GetDeclarationsUsedByMethod( MethodBase method, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration )
        {
            return GetMethodsUsingDeclaration( declaration, ReflectionSearchOptions.None );
        }

        public static MethodUsageCodeReference[] GetMethodsUsingDeclaration( MemberInfo declaration, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType )
        {
            return GetDerivedTypes( baseType, ReflectionSearchOptions.None );
        }

        public static TypeInheritanceCodeReference[] GetDerivedTypes( Type baseType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }

        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType )
        {
            return GetMembersOfType( memberType, ReflectionSearchOptions.None );
        }

        public static MemberTypeCodeReference[] GetMembersOfType( Type memberType, ReflectionSearchOptions options )
        {
            throw new NotImplementedException();
        }
    }
}
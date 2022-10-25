using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    public static class ReflectionExtensions
    {
        public static PropertyInfo GetAutomaticProperty( this FieldInfo field )
        {
            return GetAutomaticProperty( field, true );
        }

        public static PropertyInfo GetAutomaticProperty( this FieldInfo field, bool inherit )
        {
            throw new NotImplementedException();
        }

        public static bool IsAutomaticProperty( this PropertyInfo propertyInfo )
        {
            return GetBackingField( propertyInfo ) != null;
        }

        public static FieldInfo GetBackingField( this PropertyInfo propertyInfo )
        {
            throw new NotImplementedException();
        }

        public static StateMachineKind GetStateMachineKind( this MethodInfo method )
        {
            throw new NotImplementedException();
        }

        public static MethodInfo GetStateMachinePublicMethod( this MethodInfo method )
        {
            throw new NotImplementedException();
        }
    }
}
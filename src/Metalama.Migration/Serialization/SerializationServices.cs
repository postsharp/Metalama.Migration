using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides some utility method for the current namespace.
    /// </summary>
    public static class SerializationServices
    {
        /// <summary>
        /// Checks whether a given <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="FieldInfo"/>, <see cref="PropertyInfo"/>,
        /// <see cref="EventInfo"/> or <see cref="Type"/> can be safely serialized.
        /// </summary>
        /// <param name="memberInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="memberInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException( MemberInfo memberInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether a given <see cref="LocationInfo"/> can be safely serialized.
        /// </summary>
        /// <param name="locationInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="locationInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException( LocationInfo locationInfo )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks whether a given <see cref="ParameterInfo"/> can be safely serialized.
        /// </summary>
        /// <param name="parameterInfo">The declaration to be serialized.</param>
        /// <returns><c>null</c> if <paramref name="parameterInfo"/> can be safely serialized, otherwise an exception where the text describes
        /// the reason why the declaration is not serializable.</returns>
        public static PortableSerializationException GetSerializationException( ParameterInfo parameterInfo )
        {
            throw new NotImplementedException();
        }
    }
}
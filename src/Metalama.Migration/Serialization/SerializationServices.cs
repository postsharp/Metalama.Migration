using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public static class SerializationServices
    {
        public static PortableSerializationException GetSerializationException( MemberInfo memberInfo )
        {
            throw new NotImplementedException();
        }

        public static PortableSerializationException GetSerializationException( LocationInfo locationInfo )
        {
            throw new NotImplementedException();
        }

        public static PortableSerializationException GetSerializationException( ParameterInfo parameterInfo )
        {
            throw new NotImplementedException();
        }
    }
}
using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct )]
    public sealed class SerializerAttribute : Attribute
    {
        public SerializerAttribute( Type serializerType )
        {
            SerializerType = serializerType;
        }

        public Type SerializerType { get; }
    }
}
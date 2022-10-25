using System;

namespace PostSharp.Serialization
{
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
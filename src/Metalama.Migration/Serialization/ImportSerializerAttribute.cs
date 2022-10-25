using System;

namespace PostSharp.Serialization
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class ImportSerializerAttribute : Attribute
    {
        public ImportSerializerAttribute( Type objectType, Type serializerType )
        {
            ObjectType = objectType;
            SerializerType = serializerType;
        }

        public Type ObjectType { get; }

        public Type SerializerType { get; }
    }
}
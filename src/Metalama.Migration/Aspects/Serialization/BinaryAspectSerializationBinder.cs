using System;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public class BinaryAspectSerializationBinder : SerializationBinder
    {
        public BinaryAspectSerializationBinder() { }

        public override Type BindToType( string assemblyName, string typeName )
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class BinaryAspectSerializationBinder : SerializationBinder
    {
        public BinaryAspectSerializationBinder() { }

        public override Type BindToType( string assemblyName, string typeName )
        {
            throw new NotImplementedException();
        }
    }
}
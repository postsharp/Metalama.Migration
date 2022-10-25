using System;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Implementation of <see cref = "SerializationBinder" /> used at runtime when aspect instances
    ///   are deserialized. By overriding the default binder, you can resolve assembly names differently.
    ///   This can be useful if assemblies have been renamed or merged between PostSharp run and execution
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class BinaryAspectSerializationBinder : SerializationBinder
    {
        /// <summary>
        /// Initializes a new <seealso cref="BinaryAspectSerializationBinder"/>.
        /// </summary>
        public BinaryAspectSerializationBinder() { }

        /// <inheritdoc />
        public override Type BindToType( string assemblyName, string typeName )
        {
            throw new NotImplementedException();
        }
    }
}
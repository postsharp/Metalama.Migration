using System;
using System.Diagnostics;
using System.IO;
using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   When used as a value of <see cref = "AspectConfigurationAttribute" />.<see cref = "AspectConfigurationAttribute.SerializerType" />
    ///   property, specifies that the aspect should not be serialized but should instead be constructed at runtime using MSIL instructions.
    /// </summary>
    /// <remarks>
    ///   This class is <b>not</b> a serializer. When you use MSIL aspect construction, the aspect is instantiated at runtime
    ///   just as a normal custom attribute, and any initialization made at build time is lost.
    /// </remarks>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class MsilAspectSerializer : AspectSerializer
    {
        /// <inheritdoc />
        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }
    }
}
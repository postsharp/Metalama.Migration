using System;
using System.IO;
using PostSharp.Reflection;
using PostSharp.Serialization;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Implementation of <see cref = "AspectSerializer" /> based on the <see cref = "PortableFormatter" />, for use on any supported .NET platform.
    /// </summary>
    /// <seealso cref="AspectSerializer"/>
    public sealed class PortableAspectSerializer : AspectSerializer
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
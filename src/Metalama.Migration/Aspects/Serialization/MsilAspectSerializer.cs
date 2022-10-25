using System;
using System.IO;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public sealed class MsilAspectSerializer : AspectSerializer
    {
        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            throw new NotImplementedException();
        }

        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
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
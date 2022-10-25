using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Implementation of <see cref = "AspectSerializer" /> based on the
    ///   <see cref = "BinaryFormatter" /> provided by the full version
    ///   of the .NET Framework.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class BinaryAspectSerializer : AspectSerializer
    {
        /// <inheritdoc />
        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds an item to the chain of surrogate selectors
        /// used during the process of serializing aspects.
        /// </summary>
        /// <param name="selector">A new surrogate selector.</param>
        public static void ChainSurrogateSelector( ISurrogateSelector selector )
        {
            throw new NotImplementedException();
        }
    }
}
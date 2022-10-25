// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PostSharp.Extensibility;
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
            if (aspects == null) throw new ArgumentNullException(nameof(aspects));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (metadataEmitter == null) throw new ArgumentNullException(nameof(metadataEmitter));

            ISerializerFactoryProvider serializerProvider = SerializerFactoryProvider.BuiltIn;

            // Include the build-time (reflection-based) serializer, if any.
            IBuildTimeSerializerLocatorFactory buildTimeSerializerLocatorFactory = PostSharpEnvironment.CurrentProject.GetService<IBuildTimeSerializerLocatorFactory>();
            if ( buildTimeSerializerLocatorFactory != null )
            {
                serializerProvider = buildTimeSerializerLocatorFactory.Create( serializerProvider );
            }

            PortableFormatter formatter = new PortableFormatter(null, serializerProvider ) { MetadataEmitter = metadataEmitter};
            formatter.Serialize( aspects, stream );
        }

        /// <inheritdoc />
        protected override IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser )
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            
            PortableFormatter formatter = new PortableFormatter(null, null) { MetadataDispenser = metadataDispenser};
            return (IAspect[]) formatter.Deserialize( stream );
        }
    }
}

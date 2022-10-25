// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Reflection;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public abstract class AspectSerializer
    {
        public abstract void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter );

        protected abstract IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser );

        public IAspect[] Deserialize( Assembly assembly, string resourceName, IMetadataDispenser metadataDispenser )
        {
            if ( assembly == null )
            {
                throw new ArgumentNullException( nameof(assembly) );
            }

            if ( resourceName == null )
            {
                throw new ArgumentNullException( nameof(resourceName) );
            }

            var stream = assembly.GetManifestResourceStream( resourceName );

            if ( stream == null )
            {
                throw new Exception(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "In assembly '{0}', cannot find the resource stream '{1}' required by PostSharp.",
                        assembly.FullName,
                        resourceName ) );
            }

            using ( stream )
            {
                return this.Deserialize( stream, metadataDispenser );
            }
        }
    }
}
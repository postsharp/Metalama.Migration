// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    ///   Base class for all aspect serializers, whose role is to serialize aspect instances at compile-time and
    ///   deserialize them at runtime.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class AspectSerializer
    {
        /// <summary>
        ///   Serializes an array of aspects into a stream.
        /// </summary>
        /// <param name = "aspects">Array of aspects to be serialized.</param>
        /// <param name = "stream">Stream into which aspects have to be serialized.</param>
        /// <param name="metadataEmitter">A metadata emitter for the current module.</param>
        public abstract void Serialize( IAspect[] aspects, Stream stream, IMetadataEmitter metadataEmitter );



        /// <summary>
        ///   Deserializes a stream into an array if aspects.
        /// </summary>
        /// <param name = "stream">Stream containing serialized aspects.</param>
        /// <param name="metadataDispenser">Metadata dispenser to be used to resolve serialized metadata references in <paramref name="stream"/>.</param>
        /// <returns>An array of aspects.</returns>
        /// <remarks>
        ///   The implementation is not allowed to change the order or array elements.
        /// </remarks>
        protected abstract IAspect[] Deserialize( Stream stream, IMetadataDispenser metadataDispenser );
        

        /// <summary>
        ///   Deserializes aspects contained in a managed resource of an assembly.
        /// </summary>
        /// <param name = "assembly">Assembly containing the serialized aspects.</param>
        /// <param name = "resourceName">Name of the managed resources into which aspects have been serialized.</param>
        /// <param name="metadataDispenser">Metadata dispenser to be used to resolve serialized metadata references in this resource.</param>
        /// <returns>An array of aspects.</returns>
        public IAspect[] Deserialize( Assembly assembly, string resourceName, IMetadataDispenser metadataDispenser )
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            if (resourceName == null)
                throw new ArgumentNullException(nameof(resourceName));

            Stream stream = assembly.GetManifestResourceStream( resourceName );

            if ( stream == null )
            {
                throw new Exception(
                    string.Format(CultureInfo.InvariantCulture, "In assembly '{0}', cannot find the resource stream '{1}' required by PostSharp.",
                                   assembly.FullName, resourceName ) );
            }
            using ( stream )
            {
                return this.Deserialize( stream, metadataDispenser );
            }
        }

    }
}


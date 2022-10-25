// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Reflection
{
    /// <summary>
    ///   Semantics of service that deserializes metadata objects (i.e. reflection objects) that have 
    ///   been serialized by <see cref = "IMetadataEmitter" />.
    /// </summary>
    public interface IMetadataDispenser
    {
        /// <summary>
        ///   Gets the reflection object corresponding to the given index.
        /// </summary>
        /// <param name = "index">Index returned by <see cref = "IMetadataEmitter.GetMetadataIndex" />
        ///   at build time.</param>
        /// <returns>The reflection object corresponding to <paramref name = "index" />.</returns>
        object GetMetadata( int index );
    }
}

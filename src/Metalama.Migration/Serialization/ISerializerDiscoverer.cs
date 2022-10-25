// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Exposes a method <seealso cref="DiscoverSerializers"/> that allows implementations
    /// of the <seealso cref="ISerializerFactoryProvider"/> interface to discover serializer types
    /// for each type being serialized.
    /// </summary>
    /// <remarks>
    /// Only implementations of <seealso cref="ISerializerFactoryProvider"/> may implement this interface.
    /// </remarks>
    /// <seealso cref="ISerializerFactoryProvider"/>
    public interface ISerializerDiscoverer
    {
        /// <summary>
        /// Invoked by <seealso cref="PortableFormatter"/> once for every type that needs to be serialized,
        /// before <seealso cref="ISerializerFactoryProvider.GetSurrogateType"/> is invoked.
        /// </summary>
        /// <param name="objectType">Type being serialized.</param>
        void DiscoverSerializers( Type objectType );
    }
}

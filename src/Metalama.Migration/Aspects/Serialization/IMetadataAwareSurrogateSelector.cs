// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if SERIALIZABLE
using System.Runtime.Serialization;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// A <see cref="SurrogateSelector"/> that receives an <see cref="IMetadataEmitter"/>
    /// before serialization.
    /// </summary>
    public interface IMetadataAwareSurrogateSelector : ISurrogateSelector
    {
        /// <summary>
        /// Sets the <see cref="IMetadataEmitter"/>.
        /// </summary>
        /// <param name="metadataEmitter">An <see cref="IMetadataEmitter"/>.</param>
        void SetMetadataEmitter( IMetadataEmitter metadataEmitter );
    }
}

#endif
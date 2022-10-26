// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct )]
    public sealed class SerializerAttribute : Attribute
    {
        public SerializerAttribute( Type serializerType )
        {
            throw new NotImplementedException();
        }

        public Type SerializerType { get; }
    }
}
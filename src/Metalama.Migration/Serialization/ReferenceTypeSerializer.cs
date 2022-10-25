// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

#pragma warning disable 3006 // CLS Compliance.

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ReferenceTypeSerializer"/>.
    /// </summary>
    public abstract class ReferenceTypeSerializer : ISerializer
    {
        bool ISerializer.IsTwoPhase { get; }

        void ISerializer.DeserializeFields( ref object obj, IArgumentsReader initializationArguments )
        {
            this.DeserializeFields( obj, initializationArguments );
        }

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            this.SerializeObject( obj, constructorArguments, initializationArguments );
        }

        public abstract object CreateInstance( Type type, IArgumentsReader constructorArguments );

        public abstract void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments );

        public abstract void DeserializeFields( object obj, IArgumentsReader initializationArguments );

        public virtual object Convert( object value, Type targetType )
        {
            return value;
        }
    }
}
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ValueTypeSerializer{T}"/>.
    /// </summary>
    public abstract class ValueTypeSerializer<T> : ISerializer where T : struct
    {
        bool ISerializer.IsTwoPhase { get; }

        public abstract void SerializeObject( T obj, IArgumentsWriter constructorArguments );

        public abstract T DeserializeObject( IArgumentsReader constructorArguments );

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            var typedValue = (T) obj;
            this.SerializeObject( typedValue, constructorArguments );
        }

        public virtual object Convert( object value, Type targetType )
        {
            return value;
        }

        object ISerializer.CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return this.DeserializeObject( constructorArguments );
        }

        void ISerializer.DeserializeFields( ref object o, IArgumentsReader initializationArguments ) { }
    }
}
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public class SerializerFactoryProvider : ISerializerFactoryProvider
    {
        public static readonly SerializerFactoryProvider BuiltIn = null;

        public void MakeReadOnly()
        {
            throw new NotImplementedException();
        }

        public ISerializerFactoryProvider NextProvider { get; }

        public void AddSerializer<TObject, TSerializer>() where TSerializer : ISerializer, new()
        {
            this.AddSerializer( typeof(TObject), typeof(TSerializer) );
        }

        public void AddSerializer( Type objectType, Type serializerType )
        {
            throw new NotImplementedException();
        }

        public virtual Type GetSurrogateType( Type objectType )
        {
            return null;
        }

        public virtual ISerializerFactory GetSerializerFactory( Type objectType )
        {
            throw new NotImplementedException();
        }
    }
}
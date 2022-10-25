// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    
    /// <summary>
    /// Provides instances of the <see cref="ISerializerFactory"/> interface for object types that have been previously registered
    /// using <see cref="AddSerializer"/>.
    /// </summary>
    public class SerializerFactoryProvider : ISerializerFactoryProvider 
    {
        private bool isReadOnly;
        private readonly Dictionary<Type, ISerializerFactory> serializerTypes = new Dictionary<Type, ISerializerFactory>( 64 );
        private readonly ISerializerFactoryProvider nextProvider;
        private readonly ActivatorProvider activatorProvider;

        /// <summary>
        /// Gets the <see cref="SerializerFactoryProvider"/> instance that supports built-in types.
        /// </summary>
        public static readonly SerializerFactoryProvider BuiltIn = new BuiltInSerializerFactoryProvider(new ActivatorProvider());

        /// <summary>
        /// Forbids further changes in the current <see cref="SerializerFactoryProvider"/>.
        /// </summary>
        public void MakeReadOnly()
        {
            if ( this.isReadOnly )
            {
                throw new InvalidOperationException();
            }
            this.isReadOnly = true;
        }

      
        /// <summary>
        /// Initializes a new <see cref="SerializerFactoryProvider"/>.
        /// </summary>
        /// <param name="nextProvider">The next provider in the chain, or <c>null</c> if there is none.</param>
        /// <param name="activatorProvider"></param>
        public SerializerFactoryProvider( ISerializerFactoryProvider nextProvider, ActivatorProvider activatorProvider )
        {
            this.activatorProvider = activatorProvider;
            this.nextProvider = nextProvider;
        }

        /// <inheritdoc />
        public ISerializerFactoryProvider NextProvider
        {
            get
            {
                return this.nextProvider;
            }
        }

        /// <summary>
        /// Maps an object type to a serializer type (using generic type parameters).
        /// </summary>
        /// <typeparam name="TObject">Type of the serialized object.</typeparam>
        /// <typeparam name="TSerializer">Type of the serializer.</typeparam>
        public void AddSerializer<TObject, TSerializer>() where TSerializer : ISerializer, new()
        {
            this.AddSerializer( typeof(TObject), typeof(TSerializer) );
        }

        /// <summary>
        /// Maps an object type to a serializer type.
        /// </summary>
        /// <param name="objectType">Type of the serialized object.</param>
        /// <param name="serializerType">Type of the serializer (must be derived from <see cref="ISerializer"/>).</param>
        public void AddSerializer( Type objectType, Type serializerType )
        {
            if ( this.isReadOnly )
            {
                throw new InvalidOperationException();
            }

            if ( !ReflectionHelper.SafeIsAssignableFrom( typeof(ISerializer), serializerType ) )
            {
                throw new ArgumentOutOfRangeException( nameof(serializerType), "Type '{0}' does not implement ISerializer or IGenericSerializerFactory" );
            }

            this.serializerTypes.Add( objectType, new ReflectionSerializerFactory( serializerType, this.activatorProvider ) );
        }


        /// <inheritdoc />
        public virtual Type GetSurrogateType( Type objectType )
        {
            return null;
        }

        /// <inheritdoc />
        public virtual ISerializerFactory GetSerializerFactory( Type objectType )
        {
            ISerializerFactory serializerType;
            if (this.serializerTypes.TryGetValue(objectType, out serializerType))
                return serializerType;
            else if ( this.nextProvider != null )
                return this.nextProvider.GetSerializerFactory( objectType );
            else
                return null;
        }
    }
}
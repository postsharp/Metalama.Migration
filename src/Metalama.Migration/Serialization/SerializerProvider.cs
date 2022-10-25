// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    internal sealed class SerializerProvider
    {
        private readonly ISerializerFactoryProvider provider;
        private readonly SerializerProvider next;
        private readonly Dictionary<Type, ISerializer> serializers = new Dictionary<Type, ISerializer>(64);
        private readonly object sync = new object();
        
        public SerializerProvider(ISerializerFactoryProvider provider)
        {
            this.provider = provider;
            if ( provider.NextProvider != null )
            {
                this.next = new SerializerProvider( provider.NextProvider );
            }
        }

        public Type GetSurrogateType(Type objectType)
        {
            for ( ISerializerFactoryProvider currentProvider = this.provider; currentProvider != null; currentProvider = currentProvider.NextProvider )
            {
                Type surrogateType = currentProvider.GetSurrogateType( objectType );
                if ( surrogateType != null ) return surrogateType;
            }

            return objectType;
        }

        private void DiscoverSerializers( Type objectType )
        {
            for ( ISerializerFactoryProvider currentProvider = this.provider; currentProvider != null; currentProvider = currentProvider.NextProvider )
            {
                ISerializerDiscoverer serializerDiscoverer = currentProvider as ISerializerDiscoverer;
                if ( serializerDiscoverer != null )
                    serializerDiscoverer.DiscoverSerializers( objectType );
            }
        }

        public ISerializer GetSerializer(Type objectType)
        {
            
            ISerializer serializer;
            if ( !this.TryGetSerializer( objectType, out  serializer))
            {
                throw new PortableSerializationException(string.Format(CultureInfo.InvariantCulture, "Cannot find a serializer for type '{0}'.", objectType));
            }
            return serializer;
        }

        public bool TryGetSerializer( Type objectType, out ISerializer serializer )
        {
            if (objectType.HasElementType)
            {
                throw new ArgumentOutOfRangeException(nameof(objectType));
            }

            lock (this.sync)
            {

                if ( this.serializers.TryGetValue( objectType, out serializer ) )
                {
                    return true;
                }

                this.DiscoverSerializers( objectType );

                ISerializerFactory serializerFactory = this.provider.GetSerializerFactory( objectType );

                if ( serializerFactory == null )
                {
                    if ( objectType.IsGenericType() )
                    {
                        serializerFactory = this.provider.GetSerializerFactory( objectType.GetGenericTypeDefinition() );

                    }

                    if ( serializerFactory == null )
                    {
                        if ( this.next != null )
                        {
                            return this.next.TryGetSerializer( objectType, out serializer );
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                
                serializer = serializerFactory.CreateSerializer(objectType);

                
                this.serializers.Add( objectType, serializer );

                return true;
            }
        }


    }
}

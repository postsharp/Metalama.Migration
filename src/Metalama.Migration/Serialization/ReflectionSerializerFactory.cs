// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Globalization;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    internal sealed class ReflectionSerializerFactory : ISerializerFactory
    {
        private readonly Type serializerType;
        private readonly ActivatorProvider activatorProvider;

        public ReflectionSerializerFactory(Type serializerType, ActivatorProvider activatorProvider)
        {
            this.serializerType = serializerType;
            this.activatorProvider = activatorProvider;
        }

        public ISerializer CreateSerializer(Type objectType)
        {
            Type serializerTypeInstance;

            if (objectType.IsGenericTypeDefinition()) throw new ArgumentOutOfRangeException(nameof(objectType));

            if (this.serializerType.IsGenericTypeDefinition())
            {
                if (this.serializerType.GetGenericArguments().Length == objectType.GetGenericArguments().Length)
                {
                    serializerTypeInstance = this.serializerType.MakeGenericType(objectType.GetGenericArguments());
                }
                else
                {
                    throw new PortableSerializationException(
                        string.Format(CultureInfo.InvariantCulture,
                            "The serializer type '{0}' is an open generic type, but it has a different number of generic parameters than '{1}'.",
                            this.serializerType, objectType));
                }
            }
            else
            {
                serializerTypeInstance = this.serializerType;
            }


            IActivator activator = this.activatorProvider != null ? this.activatorProvider.GetActivator( serializerTypeInstance ) : null;
            object instance = activator != null ? activator.CreateInstance(serializerTypeInstance, ActivatorSecurityToken.Instance) : Activator.CreateInstance(serializerTypeInstance);

            ISerializer serializer = instance as ISerializer;
            if (serializer != null)
                return serializer;

            ISerializerFactory serializerFactory = instance as ISerializerFactory;
            if (serializerFactory != null)
                return serializerFactory.CreateSerializer(objectType);

            throw new PortableSerializationException(string.Format(CultureInfo.InvariantCulture, "Type {0} must implement interface ISerializer or ISerializerFactory.", serializerTypeInstance));

        }

        public Type SerializerType { get { return this.serializerType; } }
    }
}

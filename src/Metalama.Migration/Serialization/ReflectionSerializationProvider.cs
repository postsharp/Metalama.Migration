// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    internal sealed class ReflectionSerializationProvider : ISerializerFactoryProvider, ISerializerDiscoverer
    {
        readonly Dictionary<Type, ISerializerFactory> serializerTypes = new Dictionary<Type, ISerializerFactory>();
        readonly Dictionary<Type,bool> inspectedTypes = new Dictionary<Type, bool>();
        readonly Dictionary<Assembly,bool> inspectedAssemblies = new Dictionary<Assembly, bool>();
        readonly object sync = new object();
        private readonly ActivatorProvider activatorProvider;

        public ReflectionSerializationProvider( ActivatorProvider activatorProvider )
        {
            this.activatorProvider = activatorProvider;
        }

        public ActivatorProvider ActivatorProvider { get { return this.activatorProvider; } }

        public Type GetSurrogateType( Type objectType )
        {
            throw new NotImplementedException();
        }

        public ISerializerFactory GetSerializerFactory( Type objectType )
        {
            // If we have a generic type instance, we return null and wait to be called a second time with the generic type definition.
            if (objectType.IsGenericType() && !objectType.IsGenericTypeDefinition()) return null;

            lock (this.sync)
            {
                this.InspectType( objectType );

                ISerializerFactory serializerType;
                this.serializerTypes.TryGetValue( objectType, out serializerType );

                return serializerType;

            }
        }

        private void AddSerializer( Type objectType, Type serializerType, ActivatorProvider activatorProvider )
        {
            ISerializerFactory existingSerializerType;
            if ( this.serializerTypes.TryGetValue( objectType, out existingSerializerType ) )
            {
                // ReSharper disable once SuspiciousTypeConversion.Global
                if ( ReferenceEquals( existingSerializerType,serializerType ) )
                {
                    return;
                }
                else
                {
                    throw new PortableSerializationException(string.Format(CultureInfo.InvariantCulture, "Cannot assign serializer '{0}' to type '{1}' where this type is already assigned to serializer '{2}'.",
                        serializerType, objectType, existingSerializerType));
                }
            }

            this.serializerTypes.Add(objectType, new ReflectionSerializerFactory(serializerType, activatorProvider));    
            
        }

        private void InspectType( Type type )
        {
            if (this.inspectedTypes.ContainsKey(type)) return;

            this.inspectedTypes.Add(type, true);

            bool hasSerializer = false;
            try
            {
                foreach (object attribute in type.GetCustomAttributes(false))
                {
                    SerializerAttribute serializableAttribute = attribute as SerializerAttribute;
                    if (serializableAttribute != null && serializableAttribute.SerializerType != null )
                    {
                        hasSerializer = true;
                        this.AddSerializer(type, serializableAttribute.SerializerType, this.activatorProvider);
                        continue;
                    }

                    ImportSerializerAttribute importSerializerAttribute = attribute as ImportSerializerAttribute;
                    if (importSerializerAttribute != null)
                    {
                        this.ProcessImport(importSerializerAttribute);
                    }
                }
            }
            catch (FormatException)
            {
                // This happens on Windows Phone 7 if the aspect has a custom attribute with a generic type as an argument.
                // In this case, we ignore the exception and look for the Serializer nested type.
            }


            // For backward compatibility, we look for a by-convention class named "Serializer".
            if ( !hasSerializer )
            {
                Type serializerType = type.GetNestedType( "Serializer", BindingFlags.Public | BindingFlags.NonPublic );
                if ( serializerType != null )
                {
                    this.AddSerializer( type, serializerType, this.activatorProvider );
                }
            }


            
            Type baseType = type.GetBaseType();
            if ( baseType != null )
            {
                if (baseType.IsGenericType())
                    baseType = baseType.GetGenericTypeDefinition();

                this.InspectType( baseType );
            }

            this.InspectAssembly( type.GetAssembly() );

        }

        private void InspectAssembly( Assembly assembly )
        {
            if (this.inspectedAssemblies.ContainsKey(assembly)) return;

            this.inspectedAssemblies.Add(assembly, true);

            foreach (ImportSerializerAttribute attribute in assembly.GetCustomAttributes(typeof(ImportSerializerAttribute), false))
            {
                this.ProcessImport(attribute);
            }

        }

        private void ProcessImport( ImportSerializerAttribute importSerializerAttribute )
        {
            if ( importSerializerAttribute.ObjectType != null && importSerializerAttribute.SerializerType != null )
                this.AddSerializer( importSerializerAttribute.ObjectType, importSerializerAttribute.SerializerType, null );
        }

        public ISerializerFactoryProvider NextProvider { get { return null; } }

        public void DiscoverSerializers( Type objectType )
        {
            lock ( this.sync )
            {
                this.InspectType( objectType );
            }
        }
    }
   
}
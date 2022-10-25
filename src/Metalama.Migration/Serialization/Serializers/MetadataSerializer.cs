// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization.Serializers
{
    internal abstract class MetadataSerializer<T> : ReferenceTypeSerializer
    {
        // NOTE: We still have support for serialization without a MetadataDispenser because we want to support stand-alone use of the portable serializer.

        private const string metadataIndexFieldName = "md";

        public sealed override object CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            int metadataIndex;
            if ( constructorArguments.TryGetValue( metadataIndexFieldName, out metadataIndex ) )
            {
                if (constructorArguments.MetadataDispenser == null)
                    throw new PortableSerializationException("There is no MetadataDispenser, but the serialized stream contains a metadata reference.");
                return constructorArguments.MetadataDispenser.GetMetadata(metadataIndex);
            }

            return this.CreateInstanceImpl(type, constructorArguments);
        }

        protected abstract object CreateInstanceImpl( Type type, IArgumentsReader constructorArguments );

        public override void DeserializeFields( object obj, IArgumentsReader initializationArguments )
        { }

        public sealed override void SerializeObject(object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments)
        {
            if (constructorArguments.MetadataEmitter != null)
            {
                constructorArguments.SetValue(metadataIndexFieldName, constructorArguments.MetadataEmitter.GetMetadataIndex(obj));
            }
            else
            {
                this.SerializeObjectImpl( obj, constructorArguments );
            }
        }

        protected abstract void SerializeObjectImpl(object obj, IArgumentsWriter argumentsWriter);
    }
}

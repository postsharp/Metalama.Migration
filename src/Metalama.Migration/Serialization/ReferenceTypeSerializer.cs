using System;

#pragma warning disable 3006 // CLS Compliance.

namespace PostSharp.Serialization
{
    public abstract class ReferenceTypeSerializer : ISerializer
    {
        bool ISerializer.IsTwoPhase { get; }

        void ISerializer.DeserializeFields( ref object obj, IArgumentsReader initializationArguments )
        {
            DeserializeFields( obj, initializationArguments );
        }

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            SerializeObject( obj, constructorArguments, initializationArguments );
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
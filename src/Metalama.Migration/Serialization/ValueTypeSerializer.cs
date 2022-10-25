using System;

namespace PostSharp.Serialization
{
    public abstract class ValueTypeSerializer<T> : ISerializer where T : struct
    {
        bool ISerializer.IsTwoPhase { get; }

        public abstract void SerializeObject( T obj, IArgumentsWriter constructorArguments );

        public abstract T DeserializeObject( IArgumentsReader constructorArguments );

        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            var typedValue = (T)obj;
            SerializeObject( typedValue, constructorArguments );
        }

        public virtual object Convert( object value, Type targetType )
        {
            return value;
        }

        object ISerializer.CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return DeserializeObject( constructorArguments );
        }

        void ISerializer.DeserializeFields( ref object o, IArgumentsReader initializationArguments ) { }
    }
}
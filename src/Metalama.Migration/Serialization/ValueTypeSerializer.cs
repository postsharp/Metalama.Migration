using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Base serializer for all value types.
    /// </summary>
    public abstract class ValueTypeSerializer<T> : ISerializer where T : struct
    {
        bool ISerializer.IsTwoPhase { get; }

        /// <summary>
        /// Serializes an object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="constructorArguments">Gives access to arguments that will be passed to the <see cref="DeserializeObject"/> method during deserialization.</param>
        public abstract void SerializeObject( T obj, IArgumentsWriter constructorArguments );

        /// <summary>
        /// Creates an instance of the given type.
        /// </summary>
        /// <param name="constructorArguments">Gives access to arguments required to create the instance.</param>
        /// <returns>An instance of type <typeparamref name="T"/> initialized using <paramref name="constructorArguments"/>.</returns>
        public abstract T DeserializeObject( IArgumentsReader constructorArguments );

        /// <inheritdoc />
        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            var typedValue = (T)obj;
            SerializeObject( typedValue, constructorArguments );
        }

        /// <inheritdoc />
        public virtual object Convert( object value, Type targetType )
        {
            return value;
        }

        /// <inheritdoc />
        object ISerializer.CreateInstance( Type type, IArgumentsReader constructorArguments )
        {
            return DeserializeObject( constructorArguments );
        }

        /// <inheritdoc />
        void ISerializer.DeserializeFields( ref object o, IArgumentsReader initializationArguments ) { }
    }
}
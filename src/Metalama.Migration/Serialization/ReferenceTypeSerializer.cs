using System;

#pragma warning disable 3006 // CLS Compliance.

namespace PostSharp.Serialization
{
    /// <summary>
    /// Base serializer for all reference types.
    /// </summary>
    /// <remarks>
    /// This type is intentionally non-generic because it is intended to be derived several times, making strong typing less convenient.
    /// </remarks>
    public abstract class ReferenceTypeSerializer : ISerializer
    {
        /// <inheritdoc />
        bool ISerializer.IsTwoPhase { get; }

        /// <inheritdoc />
        void ISerializer.DeserializeFields( ref object obj, IArgumentsReader initializationArguments )
        {
            DeserializeFields( obj, initializationArguments );
        }

        /// <inheritdoc />
        void ISerializer.SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments )
        {
            SerializeObject( obj, constructorArguments, initializationArguments );
        }

        /// <summary>
        /// Creates an instance of the given type.
        /// </summary>
        /// <param name="type">Type of the instance to be created.</param>
        /// <param name="constructorArguments">Gives access to arguments required to create the instance.</param>
        /// <returns>An instance of type <paramref name="type"/> initialized using <paramref name="constructorArguments"/>.</returns>
        public abstract object CreateInstance( Type type, IArgumentsReader constructorArguments );

        /// <summary>
        /// Serializes an object
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="constructorArguments">Gives access to arguments that will be passed to the <see cref="CreateInstance"/> method during deserialization.</param>
        /// <param name="initializationArguments">Gives access to arguments that will be passed to the <see cref="DeserializeFields"/> method during deserialization.</param>
        public abstract void SerializeObject( object obj, IArgumentsWriter constructorArguments, IArgumentsWriter initializationArguments );

        /// <summary>
        /// Completes the second phase of deserialization by setting fields and other properties.
        /// </summary>
        /// <param name="obj">The object being deserialized.</param>
        /// <param name="initializationArguments">Gives access to field values.</param>
        public abstract void DeserializeFields( object obj, IArgumentsReader initializationArguments );

        /// <inheritdoc />
        public virtual object Convert( object value, Type targetType )
        {
            return value;
        }
    }
}
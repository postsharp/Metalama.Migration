using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides instances of the <see cref="ISerializerFactory"/> interface for object types that have been previously registered
    /// using <see cref="AddSerializer"/>.
    /// </summary>
    public class SerializerFactoryProvider : ISerializerFactoryProvider
    {
        /// <summary>
        /// Gets the <see cref="SerializerFactoryProvider"/> instance that supports built-in types.
        /// </summary>
        public static readonly SerializerFactoryProvider BuiltIn = null;

        /// <summary>
        /// Forbids further changes in the current <see cref="SerializerFactoryProvider"/>.
        /// </summary>
        public void MakeReadOnly()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public ISerializerFactoryProvider NextProvider { get; }

        /// <summary>
        /// Maps an object type to a serializer type (using generic type parameters).
        /// </summary>
        /// <typeparam name="TObject">Type of the serialized object.</typeparam>
        /// <typeparam name="TSerializer">Type of the serializer.</typeparam>
        public void AddSerializer<TObject, TSerializer>() where TSerializer : ISerializer, new()
        {
            AddSerializer( typeof(TObject), typeof(TSerializer) );
        }

        /// <summary>
        /// Maps an object type to a serializer type.
        /// </summary>
        /// <param name="objectType">Type of the serialized object.</param>
        /// <param name="serializerType">Type of the serializer (must be derived from <see cref="ISerializer"/>).</param>
        public void AddSerializer( Type objectType, Type serializerType )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual Type GetSurrogateType( Type objectType )
        {
            return null;
        }

        /// <inheritdoc />
        public virtual ISerializerFactory GetSerializerFactory( Type objectType )
        {
            throw new NotImplementedException();
        }
    }
}
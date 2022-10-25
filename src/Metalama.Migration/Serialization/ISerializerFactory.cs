using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Defines a method <see cref="CreateSerializer"/>, which creates instances of the <see cref="ISerializer"/> interface for
    /// given object types.
    /// </summary>
    public interface ISerializerFactory
    {
        /// <summary>
        /// Creates an instance of the <see cref="ISerializer"/> interface for a given object type.
        /// </summary>
        /// <param name="objectType">Type of object being serialized or deserialized.</param>
        /// <returns>A new instance implementing the <see cref="ISerializer"/> interface.</returns>
        ISerializer CreateSerializer( Type objectType );
    }
}
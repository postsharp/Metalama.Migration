using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// A serializer designed to serialize the internal structure of types with support for cyclic object graphs.
    /// The <see cref="PortableFormatter"/> is very similar in function and design to the <see cref="BinaryFormatter"/>,
    /// but is supported on most platforms and does not require full trust. Both formatters have similar usage:
    /// <see cref="SerializableAttribute"/> is replaced by <see cref="PSerializableAttribute"/> and
    /// <see cref="NonSerializedAttribute"/> by <see cref="PNonSerializedAttribute"/>.
    /// </summary>
    /// <see cref="PSerializableAttribute"/>
    /// 
    public sealed class PortableFormatter
    {
        /// <summary>
        /// Initializes a new <see cref="PortableFormatter"/>.
        /// </summary>
        public PortableFormatter() : this( null, null ) { }

        /// <summary>
        /// Gets the default <see cref="PortableSerializationBinder"/> that is used by a <see cref="PortableFormatter"/> to bind types to/from type names if no
        /// <see cref="PortableSerializationBinder"/> is specified.
        /// </summary>
        public static PortableSerializationBinder DefaultBinder { get; set; }

        /// <summary>
        /// Initializes a new <see cref="PortableFormatter"/>.
        /// </summary>
        /// <param name="binder">A <see cref="PortableSerializationBinder"/> customizing bindings between types and type names, or <c>null</c> to use the default implementation.</param>
        /// <param name="serializerProvider">A custom implementation of <see cref="ISerializerFactoryProvider"/>, or <c>null</c> to use the default implementation.</param>
        public PortableFormatter( PortableSerializationBinder binder, ISerializerFactoryProvider serializerProvider )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes an object (and the complete graph whose this object is the root) into a <see cref="Stream"/>.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="stream">The stream where <paramref name="obj"/> needs to be serialized.</param>
        public void Serialize( object obj, Stream stream )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deserializes a stream.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing a serialized object graph.</param>
        /// <returns>The root object of the object graph serialized in <paramref name="stream"/>.</returns>
        public object Deserialize( Stream stream )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// When deserializing PostSharp aspects, gets the <see cref="IMetadataDispenser"/> corresponding to the <see cref="IArgumentsWriter.MetadataEmitter"/> 
        /// used at build time.
        /// </summary>
        public IMetadataDispenser MetadataDispenser { get; set; }

        /// <summary>
        /// When serializing PostSharp access, gets or sets a facility that can be used to serialize metadata (<c>System.Reflection</c>) objects
        /// as MSIL, therefore making them transparent to obfuscation. 
        /// </summary>
        public IMetadataEmitter MetadataEmitter { get; set; }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if BINARY_FORMATTER
using System.Runtime.Serialization.Formatters.Binary;
#endif
using System.Text;
using PostSharp.Aspects.Serialization;
using PostSharp.Reflection;
using PostSharp.Serialization.Serializers;

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
        private readonly PortableSerializationBinder binder;
        private readonly SerializerProvider serializerProvider;

        /// <summary>
        /// Initializes a new <see cref="PortableFormatter"/>.
        /// </summary>
        public PortableFormatter() : this(null,null)
        {
            
        }

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
        public PortableFormatter(PortableSerializationBinder binder, ISerializerFactoryProvider serializerProvider)
        {
            this.binder = binder ?? DefaultBinder ?? new PortableSerializationBinder();
            this.serializerProvider = new SerializerProvider(serializerProvider ?? SerializerFactoryProvider.BuiltIn);
        }

        /// <summary>
        /// Serializes an object (and the complete graph whose this object is the root) into a <see cref="Stream"/>.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="stream">The stream where <paramref name="obj"/> needs to be serialized.</param>
        public void Serialize(object obj, Stream stream)
        {
            try
            {
                SerializationWriter serializationWriter = new SerializationWriter( stream, this, shouldReportExceptionCause: false );
                serializationWriter.Serialize( obj );
            }
            catch ( PortableSerializationException )
            {
                SerializationWriter serializationWriter = new SerializationWriter( Stream.Null, this, shouldReportExceptionCause: true );
                serializationWriter.Serialize( obj );
            }
        }

        /// <summary>
        /// Deserializes a stream.
        /// </summary>
        /// <param name="stream">A <see cref="Stream"/> containing a serialized object graph.</param>
        /// <returns>The root object of the object graph serialized in <paramref name="stream"/>.</returns>
        public object Deserialize(Stream stream)
        {
            try
            {
                SerializationReader serializationReader = new SerializationReader( stream, this, shouldReportExceptionCause: false );
                return serializationReader.Deserialize();
            }
            catch ( PortableSerializationException ) when ( stream.CanSeek )
            {
                stream.Seek( 0, SeekOrigin.Begin );
                SerializationReader serializationReader = new SerializationReader( stream, this, shouldReportExceptionCause: true );
                return serializationReader.Deserialize();
            }
        }

        /// <summary>
        /// Gets the <see cref="PortableSerializationBinder"/> used by the current <see cref="PortableFormatter"/> to bind types to/from type names.
        /// </summary>
        internal PortableSerializationBinder Binder { get { return this.binder; } }

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


        internal SerializerProvider SerializerProvider { get { return this.serializerProvider; } }
    }
}

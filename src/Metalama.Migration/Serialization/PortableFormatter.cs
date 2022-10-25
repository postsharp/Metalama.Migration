using System;
using System.IO;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public class PortableFormatter
    {
        public PortableFormatter() { }

        public static PortableSerializationBinder DefaultBinder { get; set; }

        public PortableFormatter( PortableSerializationBinder binder, ISerializerFactoryProvider serializerProvider )
        {
            throw new NotImplementedException();
        }

        public void Serialize( object obj, Stream stream )
        {
            throw new NotImplementedException();
        }

        public object Deserialize( Stream stream )
        {
            throw new NotImplementedException();
        }

        public IMetadataDispenser MetadataDispenser { get; set; }

        public IMetadataEmitter MetadataEmitter { get; set; }
    }
}
using System;

namespace PostSharp.Serialization
{
    public interface ISerializerDiscoverer
    {
        void DiscoverSerializers( Type objectType );
    }
}
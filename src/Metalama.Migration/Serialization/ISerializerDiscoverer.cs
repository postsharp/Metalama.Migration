using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public interface ISerializerDiscoverer
    {
        void DiscoverSerializers( Type objectType );
    }
}
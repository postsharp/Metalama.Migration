using System;

namespace PostSharp.Serialization
{
    public interface ISerializerFactory
    {
        ISerializer CreateSerializer( Type objectType );
    }
}
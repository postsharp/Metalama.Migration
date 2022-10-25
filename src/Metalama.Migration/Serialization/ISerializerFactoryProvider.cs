using System;

namespace PostSharp.Serialization
{
    public interface ISerializerFactoryProvider
    {
        Type GetSurrogateType( Type objectType );

        ISerializerFactory GetSerializerFactory( Type objectType );

        ISerializerFactoryProvider NextProvider { get; }
    }
}
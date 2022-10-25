using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
    public interface ISerializerFactoryProvider
    {
        Type GetSurrogateType( Type objectType );

        ISerializerFactory GetSerializerFactory( Type objectType );

        ISerializerFactoryProvider NextProvider { get; }
    }
}
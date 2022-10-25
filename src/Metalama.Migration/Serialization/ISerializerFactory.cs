using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.ISerializerFactory"/>.
    /// </summary>
    public interface ISerializerFactory
    {
        ISerializer CreateSerializer( Type objectType );
    }
}
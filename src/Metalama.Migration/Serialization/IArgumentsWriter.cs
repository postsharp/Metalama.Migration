using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Serialization.IArgumentsWriter"/>.
    /// </summary>
    [InternalImplement]
    public interface IArgumentsWriter
    {
        void SetValue( string name, object value, string scope = null );

        IMetadataEmitter MetadataEmitter { get; }
    }
}
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    [InternalImplement]
    public interface IArgumentsWriter
    {
        void SetValue( string name, object value, string scope = null );

        IMetadataEmitter MetadataEmitter { get; }
    }
}
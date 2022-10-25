using System.Runtime.Serialization;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
    /// </summary>
    public interface IMetadataAwareSurrogateSelector : ISurrogateSelector
    {
        void SetMetadataEmitter( IMetadataEmitter metadataEmitter );
    }
}
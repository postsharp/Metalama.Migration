using System.Runtime.Serialization;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    public interface IMetadataAwareSurrogateSelector : ISurrogateSelector
    {
        void SetMetadataEmitter( IMetadataEmitter metadataEmitter );
    }
}
using System.Runtime.Serialization;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Serialization
{
    /// <summary>
    /// A <see cref="SurrogateSelector"/> that receives an <see cref="IMetadataEmitter"/>
    /// before serialization.
    /// </summary>
    public interface IMetadataAwareSurrogateSelector : ISurrogateSelector
    {
        /// <summary>
        /// Sets the <see cref="IMetadataEmitter"/>.
        /// </summary>
        /// <param name="metadataEmitter">An <see cref="IMetadataEmitter"/>.</param>
        void SetMetadataEmitter( IMetadataEmitter metadataEmitter );
    }
}
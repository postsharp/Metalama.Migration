using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides write access to a collection of arguments that need to be serialized.
    /// </summary>
    [InternalImplement]
    public interface IArgumentsWriter
    {
        /// <summary>
        /// Sets the value of an argument.
        /// </summary>
        /// <param name="name">Argument name.</param>
        /// <param name="value">Argument value. The value can be <c>null</c> or must be serializable.</param>
        /// <param name="scope">An optional prefix of <paramref name="name"/>, similar to a namespace.</param>
        void SetValue( string name, object value, string scope = null );

        /// <summary>
        /// When serializing PostSharp access, gets a facility that can be used to serialize metadata (<c>System.Reflection</c>) objects
        /// as MSIL, therefore making them transparent to obfuscation. 
        /// </summary>
        /// <see cref="IArgumentsReader.MetadataDispenser"/>
        IMetadataEmitter MetadataEmitter { get; }
    }
}
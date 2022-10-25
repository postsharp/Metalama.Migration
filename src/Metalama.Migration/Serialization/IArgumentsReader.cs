using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Provides read access to the collection of deserialized arguments.
    /// </summary>
    [InternalImplement]
    public interface IArgumentsReader
    {
        /// <summary>
        /// Attempts to read a value from the collection, and does not throw an exception if the value does not exist.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="name">Argument name.</param>
        /// <param name="value">At output, set to the value of the argument named <paramref name="name"/> in the given optional <paramref name="scope"/>.</param>
        /// <param name="scope">An optional prefix of <paramref name="name"/>, similar to a namespace.</param>
        /// <returns><c>true</c> if the value is defined, otherwise <c>false</c>.</returns>
        bool TryGetValue<T>( string name, out T value, string scope = null );

        /// <summary>
        /// Reads a value from the collection, and throws an exception if the value does not exist.
        /// </summary>
        /// <typeparam name="T">Value type.</typeparam>
        /// <param name="name">Argument name.</param>
        /// <param name="scope">An optional prefix of <paramref name="name"/>, similar to a namespace.</param>
        /// <returns>The value of the argument named <paramref name="name"/> in the given optional <paramref name="scope"/>.</returns>
        T GetValue<T>( string name, string scope = null );

        /// <summary>
        /// When deserializing PostSharp aspects, gets the <see cref="IMetadataDispenser"/> corresponding to the <see cref="IArgumentsWriter.MetadataEmitter"/> 
        /// used at build time.
        /// </summary>
        IMetadataDispenser MetadataDispenser { get; }
    }
}
namespace PostSharp.Reflection
{
    /// <summary>
    ///   Semantics of a service that allows build-time code to serialize references
    ///   to metadata objects (i.e. reflection objects) in a way that is compatible with obfuscators.
    ///   References are deserialized at run-time using <see cref = "IMetadataDispenser" />.
    /// </summary>
    public interface IMetadataEmitter
    {
        /// <summary>
        ///   Gets the index of a serialized metadata reference.
        /// </summary>
        /// <param name = "metadata">A reflection object.</param>
        /// <returns>The index of <paramref name = "metadata" />, to be serialized
        ///   and deserialized at runtime with <see cref = "IMetadataDispenser.GetMetadata" />.</returns>
        int GetMetadataIndex( object metadata );
    }
}
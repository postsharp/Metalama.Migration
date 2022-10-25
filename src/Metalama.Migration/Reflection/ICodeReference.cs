namespace PostSharp.Reflection
{
    /// <summary>
    ///   Represents a reference between two declarations.
    /// </summary>
    public interface ICodeReference
    {
        /// <summary>
        ///   Gets the declaration referencing the other.
        /// </summary>
        object ReferencingDeclaration { get; }

        /// <summary>
        ///   Gets the declaration referenced by the other.
        /// </summary>
        object ReferencedDeclaration { get; }

        /// <summary>
        ///   Gets the kind of code reference.
        /// </summary>
        CodeReferenceKind ReferenceKind { get; }
    }
}
using PostSharp.Constraints;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents an element of the syntax tree representing a method body.
    /// </summary>
    [InternalImplement]
    public interface IMethodBodyElement
    {
        /// <summary>
        /// Gets the parent method body.
        /// </summary>
        IMethodBody ParentMethodBody { get; }

        /// <summary>
        /// Gets the parent element in the tree.
        /// </summary>
        IMethodBodyElement ParentElement { get; }

        /// <summary>
        /// Gets the kind of syntax element.
        /// </summary>
        MethodBodyElementKind MethodBodyElementKind { get; }
    }
}
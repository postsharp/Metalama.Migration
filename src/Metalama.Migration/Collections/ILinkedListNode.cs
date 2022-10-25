using PostSharp.Constraints;

namespace PostSharp.Collections
{
    /// <summary>
    /// Represents a node in a double-linked list.
    /// </summary>
    /// <typeparam name="T">Type of values stored in the list.</typeparam>
    [InternalImplement]
    public interface ILinkedListNode<out T>
    {
        /// <summary>
        /// Gets the value stored in the current node.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Gets the previous node in the list, or <c>null</c> if the current node is the first one in the list.
        /// </summary>
        ILinkedListNode<T> Previous { get; }

        /// <summary>
        /// Gets the next node in the list, or <c>null</c> if the current node is the last one in the list.
        /// </summary>
        ILinkedListNode<T> Next { get; }
    }
}
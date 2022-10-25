using PostSharp.Constraints;

namespace PostSharp.Collections
{
    /// <summary>
    /// Represents a double linked list.
    /// </summary>
    /// <typeparam name="T">Type of values stored in the link list.</typeparam>
    /// <seealso cref="LinkedListExtensions"/>
    [InternalImplement]
    public interface IReadOnlyLinkedList<out T>
    {
        /// <summary>
        /// Gets the first node in the list, or <c>null</c> if the list is empty.
        /// </summary>
        ILinkedListNode<T> First { get; }

        /// <summary>
        /// Gets the last node in the list, or <c>null</c> if the list is empty.
        /// </summary>
        ILinkedListNode<T> Last { get; }

        /// <summary>
        /// Determines whether the list is empty.
        /// </summary>
        bool IsEmpty { get; }
    }
}
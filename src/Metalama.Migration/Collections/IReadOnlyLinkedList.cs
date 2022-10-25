using PostSharp.Constraints;

namespace PostSharp.Collections
{
    [InternalImplement]
    public interface IReadOnlyLinkedList<out T>
    {
        ILinkedListNode<T> First { get; }

        ILinkedListNode<T> Last { get; }

        bool IsEmpty { get; }
    }
}
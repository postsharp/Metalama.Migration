using PostSharp.Constraints;

namespace PostSharp.Collections
{
    [InternalImplement]
    public interface ISinglyLinkedListNode<out T>
    {
        T Value { get; }

        ISinglyLinkedListNode<T> Next { get; }
    }
}
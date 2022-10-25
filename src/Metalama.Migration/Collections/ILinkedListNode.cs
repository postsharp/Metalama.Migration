using PostSharp.Constraints;

namespace PostSharp.Collections
{
    [InternalImplement]
    public interface ILinkedListNode<out T>
    {
        T Value { get; }

        ILinkedListNode<T> Previous { get; }

        ILinkedListNode<T> Next { get; }
    }
}
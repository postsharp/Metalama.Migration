namespace PostSharp.Collections
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// A value-type implementation of the <see cref="IReadOnlyLinkedList{T}"/> interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ReadOnlyLinkedList<T> : IReadOnlyLinkedList<T>
    {
        /// <inherit/>
        public ILinkedListNode<T> First { get; }

        /// <inherit/>
        public ILinkedListNode<T> Last { get; }

        /// <inherit/>
        public bool IsEmpty { get; }
    }
}
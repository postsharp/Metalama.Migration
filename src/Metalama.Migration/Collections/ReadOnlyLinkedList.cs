// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Collections
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// A value-type implementation of the <see cref="IReadOnlyLinkedList{T}"/> interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct ReadOnlyLinkedList<T> : IReadOnlyLinkedList<T>
    {
        internal ReadOnlyLinkedList( ILinkedListNode<T> first, ILinkedListNode<T> last ) : this()
        {
            this.First = first;
            this.Last = last;
        }

        /// <inherit/>
        public ILinkedListNode<T> First { get; private set; }

        /// <inherit/>
        public ILinkedListNode<T> Last { get; private set; }

        /// <inherit/>
        public bool IsEmpty
        {
            get { return this.First == null; }
        }
    }
}

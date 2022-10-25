using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CA1710 // Identifiers should have correct suffix
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace PostSharp.Collections
{
    /// <summary>
    /// Represents a singly-linked list. 
    /// </summary>
    /// <typeparam name="T">Type of values stored in the list.</typeparam>
    public struct ReadOnlySinglyLinkedList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets the first node of the list.
        /// </summary>
        public ISinglyLinkedListNode<T> FirstNode { get; }

        /// <summary>
        /// Determines whether the list is empty.
        /// </summary>
        public bool IsEmpty { get; }

        /// <inheritdoc />
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value-type enumerator.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public Enumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// An enumerator allowing to enumerate a <see cref="ReadOnlySinglyLinkedList{T}"/>.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            /// <inheritdoc />
            public void Dispose() { }

            /// <inheritdoc />
            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            /// <inheritdoc />
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            public T Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            /// <inheritdoc />
            object IEnumerator.Current { get; }
        }
    }
}
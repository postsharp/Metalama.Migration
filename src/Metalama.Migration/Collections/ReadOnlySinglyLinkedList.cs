// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

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
        public ISinglyLinkedListNode<T> FirstNode { get; private set; }

        internal ReadOnlySinglyLinkedList(ISinglyLinkedListNode<T> node) : this()
        {
            this.FirstNode = node;
        }

        /// <summary>
        /// Determines whether the list is empty.
        /// </summary>
        public bool IsEmpty { get { return this.FirstNode == null; }}

        /// <inheritdoc />
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this.FirstNode);
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this.FirstNode);
        }

        /// <summary>
        /// Gets a value-type enumerator.
        /// </summary>
        /// <returns>An enumerator.</returns>
        public Enumerator GetEnumerator()
        {
            return new Enumerator(this.FirstNode);
        }

        /// <summary>
        /// An enumerator allowing to enumerate a <see cref="ReadOnlySinglyLinkedList{T}"/>.
        /// </summary>
        public struct Enumerator : IEnumerator<T>
        {
            private bool started;
            private ISinglyLinkedListNode<T> cursor;

            internal Enumerator( ISinglyLinkedListNode<T> cursor )
            {
                this.cursor = cursor;
                this.started = false;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                
            }

            /// <inheritdoc />
            public bool MoveNext()
            {
                if ( this.started )
                {
                    this.cursor = this.cursor.Next;
                }
                else
                {
                    this.started = true;
                }

                return this.cursor != null;
            }

            /// <inheritdoc />
            void IEnumerator.Reset()
            {
                throw new System.NotSupportedException();
            }

            /// <inheritdoc />
            public T Current
            {
                get
                {
                    if ( !this.started )
                        throw new InvalidOperationException();

                    return this.cursor.Value;
                }
            }

            /// <inheritdoc />
            object IEnumerator.Current
            {
                get { return this.Current; }
            }
        }
    }
}

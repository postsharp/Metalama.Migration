// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CA1710 // Identifiers should have correct suffix
#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace PostSharp.Collections
{
    public struct ReadOnlySinglyLinkedList<T> : IEnumerable<T>
    {
        public ISinglyLinkedListNode<T> FirstNode { get; }

        public bool IsEmpty { get; }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public Enumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public struct Enumerator : IEnumerator<T>
        {
            public void Dispose() { }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }

            public T Current
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            object IEnumerator.Current { get; }
        }
    }
}
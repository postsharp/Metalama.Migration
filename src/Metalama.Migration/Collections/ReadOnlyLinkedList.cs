// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Collections
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    public struct ReadOnlyLinkedList<T> : IReadOnlyLinkedList<T>
    {
        public ILinkedListNode<T> First { get; }

        public ILinkedListNode<T> Last { get; }

        public bool IsEmpty { get; }
    }
}
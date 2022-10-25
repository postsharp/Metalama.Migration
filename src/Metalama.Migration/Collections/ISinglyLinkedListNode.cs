// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;


namespace PostSharp.Collections
{
    /// <summary>
    /// Represents a node in a singly linked list.
    /// </summary>
    /// <typeparam name="T">Type of values stored in the list.</typeparam>
    [InternalImplement]
    public interface ISinglyLinkedListNode<out T>
    {
        /// <summary>
        /// Gets the value stored in the current node.
        /// </summary>
        T Value { get; }
        
        /// <summary>
        /// Gets the next node in the list, or <c>null</c> if the current node is the last one in the list.
        /// </summary>
        ISinglyLinkedListNode<T> Next { get; }
    }
}


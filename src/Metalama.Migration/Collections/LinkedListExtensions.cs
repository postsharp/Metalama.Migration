// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;

namespace PostSharp.Collections
{
    /// <summary>
    /// Extensions to the <see cref="IReadOnlyLinkedList{T}"/> interface.
    /// </summary>
    public static class LinkedListExtensions
    {
        /// <summary>
        /// Transforms an <see cref="IReadOnlyLinkedList{T}"/> into an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of values.</typeparam>
        /// <param name="linkedList">A <see cref="IReadOnlyLinkedList{T}"/>, or <c>null</c>.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that can enumerate all elements in <paramref name="linkedList"/>.
        /// If <paramref name="linkedList"/> is <c>null</c>, an empty enumerable is returned.
        ///  </returns>
        public static IEnumerable<T> ToEnumerable<T>(IReadOnlyLinkedList<T> linkedList)
        {
            if (linkedList == null) yield break;

            for ( ILinkedListNode<T> cursor = linkedList.First; cursor != null; cursor = cursor.Next )
            {
                yield return cursor.Value;
            }
        }

        /// <summary>
        /// Transforms a <see cref="ReadOnlyLinkedList{T}"/> into an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of values.</typeparam>
        /// <param name="linkedList">An <see cref="ReadOnlyLinkedList{T}"/>.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> that can enumerate all elements in <paramref name="linkedList"/>.
        /// If <paramref name="linkedList"/> is <c>null</c>, an empty enumerable is returned.
        ///  </returns>
        public static IEnumerable<T> ToEnumerable<T>(ReadOnlyLinkedList<T> linkedList)
        {
            for (ILinkedListNode<T> cursor = linkedList.First; cursor != null; cursor = cursor.Next)
            {
                yield return cursor.Value;
            }
        }
    }
}

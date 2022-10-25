// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <summary>
    /// Enumerator over an empty collection that returns the type's default value from its <see cref="Current"/> properties. Its methods do nothing.
    /// </summary>
    internal sealed class EmptyNonThrowingEnumerator<T> : IEnumerator<T>
    {
        // We want the enumerator to be forgiving so that it works the same as if the state machine decorated an empty collection (in which case 
        // calling Current before the first MoveNext doesn't produce an exception). This is arbitrary, but C# iterator machines are also forgiving, so
        // it's maybe okay.
        
        /// <summary>
        /// Does nothing.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// Always returns false.
        /// </summary>
        /// <returns>False.</returns>
        public bool MoveNext() => false;

        /// <summary>
        /// Does nothing.
        /// </summary>
        public void Reset()
        {
        }

        /// <summary>
        /// Gets the default value of <typeparamref name="T"/>.
        /// </summary>
        public T Current => default;

        /// <summary>
        /// Gets the default value of <typeparamref name="T"/>.
        /// </summary>
        object IEnumerator.Current => this.Current;
    }
}
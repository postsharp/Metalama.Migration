// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals.StateMachine
{
    /// <exclude />
    internal static class IteratorStateMachineState
    {
        /// <summary>
        /// Value of an iterator state machine's state field if the state machine represents an <see cref="System.Collections.IEnumerable"/> for which <see cref="System.Collections.IEnumerable.GetEnumerator"/> wasn't yet called.
        /// </summary>
        public const int EnumeratorNotYetCreated = -2;
        /// <summary>
        /// Value of an iterator state machine's state field if the enumerator reached its end.
        /// </summary>
        public const int EnumerationEnded = -1;
        /// <summary>
        /// Value of an iterator state machine's state field just before execution of the first user code. 
        /// </summary>
        public const int BeforeUserCode = 0;
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals.StateMachine
{
    /// <exclude />
    internal static class IteratorStateMachineIsDisposingStatus
    {
        /// <summary>
        /// Value of an iterator state machine's isDisposing field if <see cref="System.IDisposable.Dispose"/> wasn't yet run or already completed, we're not
        /// inside a Dispose call.
        /// </summary>
        public const int NotDisposing = 0;
        /// <summary>
        /// Value of an iterator state machine's isDisposing field if <see cref="System.IDisposable.Dispose"/> was called and is currently doing the disposing.
        /// </summary>
        public const int DisposeInProgress = 1;
        /// <summary>
        /// Value of an iterator state machine's isDisposing field if <see cref="System.IDisposable.Dispose"/> was called, resources have been disposed of,
        /// and now PostSharp is running a final MoveNext iteration to force remaining OnSuccess/OnExit advices to run.
        /// </summary>
        public const int AfterDisposeMoveNextInProgress = 2;
    }
}
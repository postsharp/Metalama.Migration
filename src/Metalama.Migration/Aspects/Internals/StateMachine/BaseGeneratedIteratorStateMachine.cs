// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals.StateMachine
{
    /// <exclude />
    /// <summary>
    /// Base class for PostSharp-created state machines created for methods that return IEnumerable, if there's a semantically advised method boundary advice
    /// in front of a non-semantically advised advice. 
    /// </summary>
    /// <remarks>
    /// In this class, "the target method" means a newly created method to which we moved the body of the "kickoff" method (the method
    /// to which the user applied the aspects).
    /// <para>
    /// This class always uses the non-generic enumerable and the non-generic enumerator because it works for non-generic enumerables and pretty much
    /// all generic enumerables have the same methods implementing both the generic and the non-generic interfaces.
    /// </para>
    /// </remarks>
    /// <typeparam name="TElement">Type of elements of the enumerator or enumerable. If it's a non-generic enumerator or enumerable, then this is <see cref="Object"/>.</typeparam>
    // See TargetProcess #24903 for details.
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [SuppressMessage( "Microsoft.Naming", "CA1063" /* Implement IDisposable correctly */ )]
    [SuppressMessage( "Microsoft.Naming", "CA1051" /* Do not declare visible instance fields */ )]
    [Internal]
    public abstract class BaseGeneratedIteratorStateMachine<TElement> : IEnumerator<TElement>, IEnumerable<TElement>
    {
        /// <exclude />
        internal const string YieldValueFieldName = nameof(yieldValue);
        /// <exclude />
        internal const string IsDisposingFieldName = nameof(isDisposing);
        /// <exclude />
        internal const string StateFieldName = nameof(state);
        
        private IEnumerator originalEnumerator;
        /// <exclude />
        protected TElement yieldValue;
        /// <exclude />
        protected int isDisposing; // not used here, but exists for compatibility with the other iterator state machine transformations
        /// <exclude />
        protected int state = IteratorStateMachineState.BeforeUserCode; // used so that we can reuse the same code generation that exists for Roslyn iterator state machines, accessed by reflection

        private bool permanentlyDisposed; // means that we should prevent MoveNext() from doing anything, because OnExit() was called already (if it exists)

        /// <summary>
        /// Disposes the decorated enumerator and calls OnSuccess and OnExit, if OnEntry was called but OnExit wasn't yet called.
        /// </summary>
        public void Dispose()
        {
            if ( this.originalEnumerator == null )
            {
                // spec: "However, if you dispose the enumerator before calling MoveNext for the first time, it has no effect (the kickoff method isn’t called)."
                // If the enumerator wasn't created yet (before the first MoveNext() call), do nothing.
                // Calling Dispose() would require us to call the kickoff method which would trigger aspects elsewhere than in MoveNext() and would be strange.
                // I can see no good reason why a user would want to create an object and immediately dispose it without using it, so not creating the object at all
                // seems to be okay here.
                return;
            }

            this.isDisposing = IteratorStateMachineIsDisposingStatus.DisposeInProgress;
            try
            {
                if ( this.originalEnumerator is IDisposable disposable )
                {
                    disposable.Dispose();
                }
            }
            finally
            {
                this.permanentlyDisposed = true;
                this.isDisposing =  IteratorStateMachineIsDisposingStatus.AfterDisposeMoveNextInProgress;
                this.MoveNext();
                this.isDisposing = IteratorStateMachineIsDisposingStatus.NotDisposing;
            }
        }
        /// <summary>
        /// Calls the target method, possibly with some arguments changed. This method is only overridden if the target method has <see cref="IEnumerable"/>
        /// or <see cref="IEnumerable{T}" /> as the return type.
        /// </summary>
        /// <returns>The return value of the target method; or null if the target method returns an enumerator.</returns>
        public virtual IEnumerable CallTargetEnumerableMethod() => null;

        /// <summary>
        /// Calls the target method, possibly with some arguments changed. This method is only overridden if the target method has <see cref="IEnumerator"/>
        /// or <see cref="IEnumerator{T}" /> as the return type.
        /// </summary>
        /// <returns>The return value of the target method; or null if the target method returns an enumerable.</returns>
        public virtual IEnumerator CallTargetEnumeratorMethod() => null;

        /// <summary>
        /// Advances this (as an enumerator) to the next element by calling MoveNext() on the decorated enumerator, then accesses its <see cref="IEnumerator.Current"/>
        /// and stores it, so that it can be read and modified by <see cref="IOnStateMachineBoundaryAspect.OnYield"/> advices.
        /// </summary>
        /// <returns>Whatever the decorated enumerator returns.</returns>
        public virtual bool MoveNext()
        {
            if ( this.state == IteratorStateMachineState.EnumerationEnded || this.permanentlyDisposed)
            {
                // "this.state == -1" if OnException() was reached and returned FlowBehavior.Return. That means iteration is over.
                // "this.permanentlyDisposed == true" if Dispose() was called after at least one MoveNext(). That also means iteration is over, for consistency
                // with how iterator methods work.
                return false;
            }
            if ( this.originalEnumerator == null )
            {
                this.ConnectToDecoratedEnumerator();
            }

            bool shouldContinue = this.originalEnumerator.MoveNext();
            if ( shouldContinue )
            {
                // True means that we can access a new element:
                this.yieldValue = (TElement) this.originalEnumerator.Current;
                // False means we keep returning the previous one, which is more forgiving that C# iterators (such as List<T>.Iterator) usually are, but
                // it's in line with what iterator methods do.
            }

            return shouldContinue;
        }
        
        /// <summary>
        /// Creates an enumerator from this enumerable as a copy of this instance. See Remarks.
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        /// <remarks>
        /// This method is only called if this instance represents an enumerable. It's called only from <see cref="IEnumerable.GetEnumerator"/> and
        /// <see cref="IEnumerable{T}.GetEnumerator"/> and its return value represents the enumerator.
        /// <para>
        /// This way, each enumerator has its own set of arguments and its own method execution tag, so and if you change the arguments or the tag, it will
        /// only affect that enumerator an not all of them. 
        /// </para>
        /// </remarks>
        public abstract BaseGeneratedIteratorStateMachine<TElement> CreateCopy();

        private void ConnectToDecoratedEnumerator()
        {
            IEnumerable enumerable = this.CallTargetEnumerableMethod();
            IEnumerator enumerator = enumerable?.GetEnumerator() ?? this.CallTargetEnumeratorMethod();
            this.originalEnumerator = enumerator ?? new EmptyNonThrowingEnumerator<TElement>();
        }

        /// <exclude />
        public void Reset() => this.originalEnumerator.Reset();

        /// <exclude />
        public TElement Current => this.yieldValue;

        /// <exclude />
        object IEnumerator.Current => this.Current;

        // I suspect, though I have no proof, that our implementation of GetEnumerator() is not thread-safe.
        // But that's not a guarantee in general on methods that return IEnumerable, so it should not be a concern.
        
        IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator() => this.CreateCopy();

        IEnumerator IEnumerable.GetEnumerator() => this.CreateCopy();
    }
}
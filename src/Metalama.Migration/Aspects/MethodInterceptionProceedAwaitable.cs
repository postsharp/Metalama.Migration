// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Represents the asynchronous proceed operation that calls the next node in the chain of invocation.
    /// </summary>
    public struct MethodInterceptionProceedAwaitable
    {
        private readonly IAsyncMethodInterceptionArgsInternal args;
        private readonly Task task;

        internal MethodInterceptionProceedAwaitable( Task task, IAsyncMethodInterceptionArgsInternal args )
        {
            this.args = args;
            this.task = task;
        }

        /// <summary>
        /// Gets an awaiter used to await the asynchronous method invocation.
        /// </summary>
        /// <returns><see cref="MethodInterceptionProceedAwaiter"/> used to await the asynchronous method invocation.</returns>
        public MethodInterceptionProceedAwaiter GetAwaiter()
        {
            if ( this.task == null )
            {
                throw new InvalidOperationException( "Cannot get an awaiter for the intercepted method because the method returned a null Task." );
            }

            return new MethodInterceptionProceedAwaiter( this.task, this.args );
        }

        /// <summary>
        /// Gets the underlying task that represents the asynchronous proceed operation.
        /// </summary>
        /// <returns>The <see cref="Task"/> instance that represents the asynchronous proceed operation.</returns>
        public Task GetTask()
        {
            if ( this.task == null )
            {
                return null;
            }

            return this.args.AwaitResult( this.task );
        }
    }
}
#endif

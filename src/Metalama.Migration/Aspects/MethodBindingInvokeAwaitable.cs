// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if ASYNCAWAIT

using System;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types
    /// <summary>
    /// Represents the awaitable result of the asynchronous method invocation.
    /// Await this value to get the <c>System.Object</c> instance containing the return value of the async method.
    /// The result of the await is <c>null</c> for async methods that do not return any value.
    /// </summary>
    public struct MethodBindingInvokeAwaitable
    {
        private readonly Task task;
        private readonly ITaskAdapter taskAdapter;

        internal MethodBindingInvokeAwaitable( Task task, ITaskAdapter taskAdapter )
        {
            this.task = task;
            this.taskAdapter = taskAdapter;
        }

        /// <summary>
        /// Gets an awaiter used to await the asynchronous method invocation.
        /// </summary>
        /// <returns><see cref="MethodBindingInvokeAwaiter"/> used to await the asynchronous method invocation.</returns>
        public MethodBindingInvokeAwaiter GetAwaiter()
        {
            if (this.task == null)
            {
                throw new InvalidOperationException( "Cannot get an awaiter for the intercepted method because the method returned a null Task." );
            }

            return new MethodBindingInvokeAwaiter( this.task, this.taskAdapter );
        }

        /// <summary>
        /// Gets the underlying task that was returned by the asynchronous method invocation.
        /// </summary>
        /// <returns>The <see cref="Task"/> instance returned by the asynchronous method.</returns>
        public Task GetTask()
        {
            return this.task;
        }
    }
}

#endif
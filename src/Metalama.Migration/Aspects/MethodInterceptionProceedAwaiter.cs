// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;

#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace PostSharp.Aspects
{
    /// <summary>
    /// Represents the awaiter for the completion of the asynchronous proceed operation.
    /// </summary>
    public struct MethodInterceptionProceedAwaiter : ICriticalNotifyCompletion
    {
        private readonly IAsyncMethodInterceptionArgsInternal args;
        private readonly Task task;
        private readonly TaskAwaiter taskAwaiter;

        internal MethodInterceptionProceedAwaiter( Task task, IAsyncMethodInterceptionArgsInternal args )
        {
            this.args = args;
            this.task = task;
            this.taskAwaiter = this.task.GetAwaiter();
        }

        /// <summary>
        /// Gets a value that indicates whether a yield is not required.
        /// </summary>
        public bool IsCompleted
        {
            get { return this.taskAwaiter.IsCompleted; }
        }

        /// <summary>
        /// Ends the await operation.
        /// </summary>
        public void GetResult()
        {
            this.taskAwaiter.GetResult();
            this.args.GetResult( this.task );
        }

        /// <inheritdoc />
        public void OnCompleted( Action continuation )
        {
            this.taskAwaiter.OnCompleted( continuation );
        }

        /// <inheritdoc />
        [SecurityCritical]
        public void UnsafeOnCompleted( Action continuation )
        {
            this.taskAwaiter.UnsafeOnCompleted( continuation );
        }
    }
}
#endif

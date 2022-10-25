// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Represents the awaiter for the result of the asynchronous method invocation.
    /// </summary>
    public struct MethodBindingInvokeAwaiter : ICriticalNotifyCompletion
    {
        private readonly Task task;
        private TaskAwaiter taskAwaiter;
        private readonly ITaskAdapter taskAdapter;

        internal MethodBindingInvokeAwaiter( Task task, ITaskAdapter taskAdapter )
        {
            this.taskAwaiter = task.GetAwaiter();
            this.task = task;
            this.taskAdapter = taskAdapter;
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
        /// <returns>The result of the asynchronous invocation.</returns>
        public object GetResult()
        {
            this.taskAwaiter.GetResult();
            return this.taskAdapter.GetResult( this.task );
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

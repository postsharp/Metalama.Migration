using System;
using System.Runtime.CompilerServices;
using System.Security;

#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace PostSharp.Aspects
{
    /// <summary>
    /// Represents the awaiter for the completion of the asynchronous proceed operation.
    /// </summary>
    public struct MethodInterceptionProceedAwaiter : ICriticalNotifyCompletion
    {
        /// <summary>
        /// Gets a value that indicates whether a yield is not required.
        /// </summary>
        public bool IsCompleted { get; }

        /// <summary>
        /// Ends the await operation.
        /// </summary>
        public void GetResult()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void OnCompleted( Action continuation )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        [SecurityCritical]
        public void UnsafeOnCompleted( Action continuation )
        {
            throw new NotImplementedException();
        }
    }
}
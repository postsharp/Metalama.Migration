using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Represents the awaiter for the result of the asynchronous method invocation.
    /// </summary>
    public struct MethodBindingInvokeAwaiter : ICriticalNotifyCompletion
    {
        /// <summary>
        /// Gets a value that indicates whether a yield is not required.
        /// </summary>
        public bool IsCompleted { get; }

        /// <summary>
        /// Ends the await operation.
        /// </summary>
        /// <returns>The result of the asynchronous invocation.</returns>
        public object GetResult()
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
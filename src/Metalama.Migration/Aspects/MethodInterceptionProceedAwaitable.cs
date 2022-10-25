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
        /// <summary>
        /// Gets an awaiter used to await the asynchronous method invocation.
        /// </summary>
        /// <returns><see cref="MethodInterceptionProceedAwaiter"/> used to await the asynchronous method invocation.</returns>
        public MethodInterceptionProceedAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the underlying task that represents the asynchronous proceed operation.
        /// </summary>
        /// <returns>The <see cref="Task"/> instance that represents the asynchronous proceed operation.</returns>
        public Task GetTask()
        {
            throw new NotImplementedException();
        }
    }
}
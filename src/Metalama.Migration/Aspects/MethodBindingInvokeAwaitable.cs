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
        /// <summary>
        /// Gets an awaiter used to await the asynchronous method invocation.
        /// </summary>
        /// <returns><see cref="MethodBindingInvokeAwaiter"/> used to await the asynchronous method invocation.</returns>
        public MethodBindingInvokeAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the underlying task that was returned by the asynchronous method invocation.
        /// </summary>
        /// <returns>The <see cref="Task"/> instance returned by the asynchronous method.</returns>
        public Task GetTask()
        {
            throw new NotImplementedException();
        }
    }
}
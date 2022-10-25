using System;
using System.Runtime.CompilerServices;
using System.Security;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// No equivalent in Metalama. To override an async method, implement the <see cref="OverrideMethodAspect"/>.<see cref="OverrideMethodAspect.OverrideAsyncMethod"/>
    /// method and call <see cref="meta"/>.<see cref="meta.ProceedAsync"/>.
    /// </summary>
    public struct MethodBindingInvokeAwaiter : ICriticalNotifyCompletion
    {
        public bool IsCompleted { get; }

        public object GetResult()
        {
            throw new NotImplementedException();
        }

        public void OnCompleted( Action continuation )
        {
            throw new NotImplementedException();
        }

        [SecurityCritical]
        public void UnsafeOnCompleted( Action continuation )
        {
            throw new NotImplementedException();
        }
    }
}
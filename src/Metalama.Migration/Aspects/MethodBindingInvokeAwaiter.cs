using System;
using System.Runtime.CompilerServices;
using System.Security;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

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
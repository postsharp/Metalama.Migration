using System;
using System.Runtime.CompilerServices;
using System.Security;

#pragma warning disable CA1815 // Override equals and operator equals on value types

namespace PostSharp.Aspects
{
    public struct MethodInterceptionProceedAwaiter : ICriticalNotifyCompletion
    {
        public bool IsCompleted { get; }

        public void GetResult()
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
using System;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    public struct MethodInterceptionProceedAwaitable
    {
        public MethodInterceptionProceedAwaiter GetAwaiter()
        {
            throw new NotImplementedException();
        }

        public Task GetTask()
        {
            throw new NotImplementedException();
        }
    }
}
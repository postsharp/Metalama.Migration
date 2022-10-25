using System;

namespace PostSharp.Extensibility.BuildTimeLogging
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    public struct BuildTimeLogActivity : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
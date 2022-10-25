// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

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
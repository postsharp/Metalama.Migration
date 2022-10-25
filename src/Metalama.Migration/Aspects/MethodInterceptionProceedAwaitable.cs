// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using System;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// No equivalent in Metalama. To override an async method, implement the <see cref="OverrideMethodAspect"/>.<see cref="OverrideMethodAspect.OverrideAsyncMethod"/>
    /// method and call <see cref="meta"/>.<see cref="meta.ProceedAsync"/>.
    /// </summary>
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
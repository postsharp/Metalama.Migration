// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Code.AsyncInfo"/>.
    /// </summary>
    public enum StateMachineKind
    {
        None,

        Iterator,

        Async,

        AsyncIterator
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Flags]
    [Internal]
    public enum RuntimeInitializeOptimizations
    {
#pragma warning disable 1591
        None,
        Ignore = 1,
#pragma warning restore 1591
    }
}

// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Flags]
    [Internal]
    public enum EventInterceptionAdviceOptimizations
    {
#pragma warning disable 1591
        None,
        IgnoreGetEvent = 1,
        IgnoreGetDeclarationIdentifier = 2,
        IgnoreAllEventArgsMembers = IgnoreGetEvent | IgnoreGetDeclarationIdentifier,
        IgnoreEventArgs = 1024,
        IgnoreAdvice = 2048,
        IgnoreAll = IgnoreAllEventArgsMembers | IgnoreEventArgs | IgnoreAdvice
#pragma warning restore 1591
    }
}

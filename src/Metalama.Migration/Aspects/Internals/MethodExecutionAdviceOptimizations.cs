// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    [Flags]
    public enum MethodExecutionAdviceOptimizations
    {
#pragma warning disable 1591
        None,
        IgnoreGetMethod = 1,
        IgnoreSetFlowBehavior = 2,
        IgnoreGetArguments = 4,
        IgnoreSetArguments = 8,
        IgnoreGetInstance = 16,
        IgnoreSetInstance = 32,
        IgnoreGetException = 64,
        IgnoreGetReturnValue = 128,
        IgnoreSetReturnValue = 256,
        IgnoreGetMethodExecutionTag = 512,
        IgnoreSetMethodExecutionTag = 4096,
        IgnoreGetYieldValue = 0x2000,
        IgnoreSetYieldValue =0x4000,
        IgnoreGetDeclarationIdentifier = 0x8000,
        IgnoreMethodExecutionTag = IgnoreGetMethodExecutionTag | IgnoreSetMethodExecutionTag,
        IgnoreAllEventArgsMembers = IgnoreGetMethod | IgnoreSetFlowBehavior | IgnoreGetArguments
                                    | IgnoreSetArguments | IgnoreGetInstance | IgnoreSetInstance | IgnoreGetReturnValue
                                    | IgnoreSetReturnValue | IgnoreGetException | IgnoreGetMethodExecutionTag | IgnoreSetMethodExecutionTag
                                    | IgnoreGetYieldValue | IgnoreSetYieldValue | IgnoreGetDeclarationIdentifier,
        IgnoreEventArgs = 1024,
        IgnoreAdvice = 2048,
        IgnoreAll = IgnoreAllEventArgsMembers | IgnoreEventArgs | IgnoreAdvice
#pragma warning restore 1591
    }
}

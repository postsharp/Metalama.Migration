// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    [Flags]
    public enum LocationInterceptionAdviceOptimizations
    {
#pragma warning disable 1591
        None,

        /// <summary>
        /// If set, it means that <see cref="LocationLevelAdviceArgs.Location"/> is not accessed, so we don't need to emit code that would set it.
        /// </summary>
        IgnoreGetLocation = 1,
        /// <summary>
        /// If set, it means that <see cref="LocationLevelAdviceArgs.LocationName"/> is not accessed, so we don't need to emit code that would set it.
        /// </summary>
        IgnoreGetLocationName = 2,
        /// <summary>
        /// If set, it means that <see cref="LocationLevelAdviceArgs.LocationFullName"/> is not accessed, so we don't need to emit code that would set it.
        /// </summary>
        IgnoreGetLocationFullName = 4,

        IgnoreGetDeclarationIdentifier = 8,

        IgnoreAllEventArgsMembers = IgnoreGetLocation | IgnoreGetLocationName | IgnoreGetLocationFullName | IgnoreGetDeclarationIdentifier,

        IgnoreEventArgs = 1024,

        IgnoreAdvice = 2048,

        IgnoreAll = IgnoreAllEventArgsMembers | IgnoreEventArgs | IgnoreAdvice
#pragma warning restore 1591
    }
}

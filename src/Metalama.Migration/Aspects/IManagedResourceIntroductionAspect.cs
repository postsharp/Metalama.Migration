// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Semantics of an aspect that, when applied to an assembly, adds a managed resource to this assembly.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "ManagedResourceIntroductionAspect" /> for details.
    /// </remarks>
    /// <seealso cref = "ManagedResourceIntroductionAspect" />
    /// <seealso cref = "ManagedResourceIntroductionAspectConfiguration" />
    public interface IManagedResourceIntroductionAspect : IAspect
    {
    }
}


// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;

#pragma warning disable CA1040 // Avoid empty interfaces
// TODO: Merge run-time semantics and run-time semantics of aspect interfaces? It would avoid empty interfaces.

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Semantics of an aspect that, when applied to a target, adds a custom attribute to this target.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "CustomAttributeIntroductionAspect" /> for details.
    /// </remarks>
    /// <seealso cref = "CustomAttributeIntroductionAspect" />
    /// <seealso cref = "CustomAttributeIntroductionAspectConfiguration" />
    public interface ICustomAttributeIntroductionAspect : IAspect
    {
    }
}

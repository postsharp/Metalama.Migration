// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Runtime.InteropServices;
using PostSharp.Aspects.Configuration;
using PostSharp.Constraints;
using PostSharp.Extensibility;

#pragma warning disable CA1040 // Avoid empty interfaces


namespace PostSharp.Aspects
{
    /// <summary>
    ///   Base interface for run-time semantics of all aspects.
    /// </summary>
    /// <seealso cref = "IAspectBuildSemantics" />
    /// <seealso cref = "AspectConfiguration" />
    /// <seealso cref = "Aspect" />
    [RequirePostSharp( null, "AspectWeaver" )]
    public interface IAspect
    {
    }

}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Runtime.InteropServices;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects applied at assembly level.
    /// </summary>
    /// <remarks>
    ///   An assembly-level aspect has no equivalent to <b>RuntimeInitialize</b> since assemblies are never initialized.
    /// </remarks>
    /// <seealso cref = "IAssemblyLevelAspectBuildSemantics" />
    /// <seealso cref = "AssemblyLevelAspect" />
    public interface IAssemblyLevelAspect : IAspect
    {
    }


}
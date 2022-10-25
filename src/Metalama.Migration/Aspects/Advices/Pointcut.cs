#pragma warning disable CA1710 // Identifiers should have correct suffix

// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate the code model exposed on <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public abstract class Pointcut : Attribute { }
}
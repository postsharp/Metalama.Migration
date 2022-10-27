
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.


// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate the code model exposed on <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public abstract class Pointcut : Attribute { }
}
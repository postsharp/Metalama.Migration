// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

#pragma warning disable CA1710 // Identifiers should have correct suffix

// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method,use advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>
    /// and pass <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/> as the target declaration.
    /// </summary>
    public sealed class SelfPointcut : Pointcut { }
}
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.OverrideAccessors(Metalama.Framework.Code.IEvent, string?, string?, string?, object?, object?)"/>
    /// </summary>
    /// <seealso href="@overriding-events"/>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnEventAddHandlerAdvice : GroupingAdvice { }
}
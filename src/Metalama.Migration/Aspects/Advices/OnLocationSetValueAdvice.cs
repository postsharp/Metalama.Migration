// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.OverrideAccessors(Metalama.Framework.Code.IEvent, string?, string?, string?, object?, object?)"/>
    /// or <see cref="IAdviceFactory.Override(Metalama.Framework.Code.IFieldOrProperty, string, object?)"/>
    /// </summary>
    /// <seealso href="@overriding-properties"/>    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnLocationSetValueAdvice : GroupingAdvice { }
}
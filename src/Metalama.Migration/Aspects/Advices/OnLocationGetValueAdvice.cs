using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.OverrideAccessors(Metalama.Framework.Code.IFieldOrProperty, in GetterTemplateSelector, string?, object?, object?)"/>
    /// or <see cref="IAdviceFactory.Override(Metalama.Framework.Code.IFieldOrProperty, string, object?)"/>
    /// </summary>
    /// <seealso href="@overriding-properties"/>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnLocationGetValueAdvice : GroupingAdvice { }
}
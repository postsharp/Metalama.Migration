#pragma warning disable CA1710 // Identifiers should have correct suffix
using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.Override(Metalama.Framework.Code.IMethod,in Metalama.Framework.Aspects.MethodTemplateSelector,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@overriding-methods"/>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnMethodSuccessAdvice : OnMethodBoundaryAdvice { }
}
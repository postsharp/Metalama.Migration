using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this feature in Metalama.
    /// </summary>
    /// <seealso href="@overriding-events"/>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnEventInvokeHandlerAdvice : GroupingAdvice { }
}
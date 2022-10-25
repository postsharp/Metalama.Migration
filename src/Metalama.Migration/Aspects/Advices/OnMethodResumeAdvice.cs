#pragma warning disable CA1710 // Identifiers should have correct suffix

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this advice in Metalama and it is currently not possible to build the equivalent feature.
    /// </summary>
    [Obsolete( "", true )]
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public sealed class OnMethodResumeAdvice : OnMethodBoundaryAdvice { }
}
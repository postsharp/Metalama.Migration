#pragma warning disable CA1710 // Identifiers should have correct suffix

using System;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public sealed class OnMethodYieldAdvice : OnMethodBoundaryAdvice { }
}
using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public class LocationValidationAdvice : GroupingAdvice
    {
        public int Priority { get; set; } = int.MaxValue;
    }
}
using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and call
    ///  <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.AddContract(Metalama.Framework.Code.IParameter,string,Metalama.Framework.Aspects.ContractDirection,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@contracts"/>
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true )]
    public class LocationValidationAdvice : GroupingAdvice
    {
        public int Priority { get; set; } = int.MaxValue;
    }
}
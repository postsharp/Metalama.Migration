using System;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Aspects.InitializerKind,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@initializers"/>
    [AttributeUsage( AttributeTargets.Method, Inherited = false )]
    public sealed class InitializeAspectInstanceAdvice : Advice { }
}
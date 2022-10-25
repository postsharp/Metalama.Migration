using System;
using Metalama.Framework.Aspects;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="Advice"/>.<see cref="IAdviceFactory.AddInitializer(Metalama.Framework.Code.INamedType,string,Metalama.Framework.Aspects.InitializerKind,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@initializers"/>
    [AttributeUsage( AttributeTargets.Method, Inherited = false )]
    public sealed class OnAspectsInitializedAdvice : Advice { }
}
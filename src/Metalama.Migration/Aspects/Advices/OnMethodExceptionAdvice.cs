using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method of an aspect class, specifies
    ///   that this method is an advice having the same semantics as <see cref = "OnMethodBoundaryAspect.OnException" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "OnMethodBoundaryAspect.OnException" />. However, it can be static.
    ///   </para>
    ///   <br />
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='onMethodBoundaryAdvice']/*" />
    /// </remarks>
    /// <seealso cref = "OnMethodBoundaryAspect" />
    /// <seealso cref = "OnMethodExitAdvice" />
    /// <seealso cref = "OnMethodSuccessAdvice" />
    /// <seealso cref = "OnMethodEntryAdvice" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public sealed class OnMethodExceptionAdvice : OnMethodBoundaryAdvice { }
}
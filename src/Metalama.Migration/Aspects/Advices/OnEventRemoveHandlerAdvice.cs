using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method of an aspect class, specifies that this method is an advice
    ///   having the same semantics as <see cref = "IEventInterceptionAspect.OnRemoveHandler" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "IEventInterceptionAspect.OnRemoveHandler" />. However, it can be static.
    ///   </para>
    ///   <br />
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='eventInterceptionAdvice']/*" />
    ///   <br />
    ///   <include file = "../Documentation.xml" path = "/documentation/section[@name='eventInterceptionAdvice']/*" />
    /// </remarks>
    /// <remarks>
    /// </remarks>
    /// <seealso cref = "EventInterceptionAspect" />
    /// <seealso cref = "OnEventAddHandlerAdvice" />
    /// <seealso cref = "OnEventInvokeHandlerAdvice" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public sealed class OnEventRemoveHandlerAdvice : GroupingAdvice { }
}
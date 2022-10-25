using System;
using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Interface through which an event-level aspect or advice can
    ///   invoke the next node in the chain of invocation.
    /// </summary>
    /// <seealso cref="PostSharp.Aspects.Advices.ImportMemberAttribute"/>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectBindings']/*" />
    [InternalImplement]
    public interface IEventBinding
    {
        /// <summary>
        ///   Invoke the <c>Add</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance on which the event is defined (<c>null</c> if the event is static).</param>
        /// <param name = "handler">Handler to be added to the event.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        void AddHandler( ref object instance, Delegate handler );

        /// <summary>
        ///   Invoke the <c>Remove</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance on which the event is defined (<c>null</c> if the event is static).</param>
        /// <param name = "handler">Handler to be removed from the event.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        void RemoveHandler( ref object instance, Delegate handler );

        /// <summary>
        ///   Invoke the <c>Invoke</c> semantic on the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance on which the event is defined (<c>null</c> if the event is static).</param>
        /// <param name = "handler">Handler to be removed from the event.</param>
        /// <param name = "arguments">Arguments with which the <paramref name = "handler" /> should be invoked.</param>
        /// <returns>The value returned by the handler.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='invokeEventHandler']/*" />
        /// </remarks>
        object InvokeHandler( ref object instance, Delegate handler, Arguments arguments );
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on an event, intercepts invocations of its semantics <c>Add</c> (<see cref = "OnAddHandler" />), 
    ///   <c>Remove</c> (<see cref = "OnRemoveHandler" />) and <c>Invoke</c> (<see cref = "OnInvokeHandler" />) semantics.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     For details, see <see cref = "EventInterceptionAspect" />
    ///   </para>
    /// </remarks>   /// <see cref = "EventInterceptionAspect" />
    /// <see cref = "EventInterceptionAspectConfiguration" />
    /// <see cref = "EventInterceptionAspectConfigurationAttribute" />
    [HasInheritedAttribute]
    public interface IEventInterceptionAspect : IEventLevelAspect
    {
        /// <summary>
        ///   Method invoked <i>instead</i> of the <c>Add</c> semantic of the event to which the current aspect is applied,
        ///   i.e. when a new delegate is added to this event.
        /// </summary>
        /// <param name = "args">Handler arguments.</param>
        /// <remarks>
        ///   <para>
        ///    This advice does not intercept the initializer of a field-like event. If you want to intercept the adding of all handlers,
        /// do not use event initializers and instead add the initial handler in the constructor.
        ///   </para>
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='eventInterceptionAdvice']/*" />
        /// </remarks>
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        void OnAddHandler( EventInterceptionArgs args );

        /// <summary>
        ///   Method invoked <i>instead</i> of the <c>Remove</c> semantic of the event to which the current aspect is applied,
        ///   i.e. when a delegate is removed from this event.
        /// </summary>
        /// <param name = "args">Handler arguments.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='eventInterceptionAdvice']/*" />
        /// </remarks>
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        void OnRemoveHandler( EventInterceptionArgs args );

        /// <summary>
        ///   Method invoked when the event to which the current aspect is applied is fired, <i>for each</i> delegate
        ///   of this event, and <i>instead of</i> invoking this delegate.
        /// </summary>
        /// <param name = "args">Handler arguments.</param>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='eventInterceptionAdvice']/*" />
        ///   <br />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='invokeEventHandler']/*" />
        /// </remarks>
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        void OnInvokeHandler( EventInterceptionArgs args );
    }
}
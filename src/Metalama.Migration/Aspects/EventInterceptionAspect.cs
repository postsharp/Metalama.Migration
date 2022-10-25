// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspect that, when applied on an event, intercepts invocations of its semantics <c>Add</c> (<see cref="OnAddHandler"/>), 
    /// <c>Remove</c> (<see cref="OnRemoveHandler"/>) and <c>Invoke</c> (<see cref="OnInvokeHandler"/>).
    /// </summary>
    /// <remarks>
    /// <para>
    /// Applying an aspect of type <see cref="EventInterceptionAspect"/> to an event results in the <c>add</c> and <c>remove</c>
    /// methods of the event to be replaced by a call to <see cref="OnAddHandler"/> and <see cref="OnRemoveHandler"/>, respectively.
    /// The original accessor body is moved into new methods, which the aspect code can call by invoking <see cref="EventInterceptionArgs.ProceedAddHandler"/>
    /// or <see cref="EventInterceptionArgs.ProceedRemoveHandler"/>.
    /// </para>
    /// <para>
    /// The method <see cref="OnInvokeHandler"/>, if defined, is called instead when the event is raised, <i>once for every handler</i> that has been added
    /// to the list. When you define <see cref="OnInvokeHandler"/> method, PostSharp will use a broker object to control access to the event; this broker
    /// object will be the unique subscriber of the event, and maintains its own list of subscribers.
    /// </para>
    /// <para>
    ///     <note>
    ///         The aspect works only when caller code access the event through its <c>add</c>/<c>remove</c> semantics. It does not work when the caller
    ///         code bypasses the event semantics and accesses directly its implementation (the underlying field of the event, typically). The C# compiler
    ///         is known to bypass the semantics when the event is accessed directly from the class declaring it (it accesses directly the private field
    ///         whenever it can).
    ///     </note>
    /// </para>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    ///  <include file="Documentation.xml" path="/documentation/section[@name='seeAlsoInterceptionAspects']/*"/>
#if SERIALIZABLE
    [Serializable]
#endif
    [HasInheritedAttribute]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [MulticastAttributeUsage(MulticastTargets.Event, AllowMultiple = true, PersistMetaData = false, TargetMemberAttributes = MulticastAttributes.NonAbstract)]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true)]
    [AspectConfigurationAttributeType( typeof(EventInterceptionAspectConfigurationAttribute) )]
    [Serializer(null)]
    public abstract class EventInterceptionAspect : EventLevelAspect, IEventInterceptionAspect

    {
        /// <inheritdoc />
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        [EventInterceptionAdviceOptimization( EventInterceptionAdviceOptimizations.IgnoreAdvice )]
        public virtual void OnAddHandler( EventInterceptionArgs args )
        {
            args.ProceedAddHandler();
        }

        /// <inheritdoc />
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        [EventInterceptionAdviceOptimization( EventInterceptionAdviceOptimizations.IgnoreAdvice )]
        public virtual void OnRemoveHandler( EventInterceptionArgs args )
        {
            args.ProceedRemoveHandler();
        }

        /// <inheritdoc />
        [RequiresEventInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        [EventInterceptionAdviceOptimization( EventInterceptionAdviceOptimizations.IgnoreAdvice )]
        public virtual void OnInvokeHandler( EventInterceptionArgs args )
        {
            args.ProceedInvokeHandler();
        }


        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new EventInterceptionAspectConfiguration();
        }

    }
}
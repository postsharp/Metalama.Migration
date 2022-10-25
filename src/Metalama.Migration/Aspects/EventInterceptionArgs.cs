// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Arguments of handlers of aspects of the type <see cref = "EventInterceptionAspect" />.
    /// </summary>
    /// <seealso cref = "EventInterceptionAspect" />
    /// <remarks>
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgs']/*" />
    /// </remarks>
    /// <seealso cref = "EventInterceptionAspect" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class EventInterceptionArgs : AdviceArgs
    {
        /// <summary>
        ///   Initializes a new <see cref = "EventInterceptionArgs" />.
        /// </summary>
        /// <param name = "instance">The instance related to the aspect handler invocation, or
        ///   <c>null</c> if the handler is associated to a static element.</param>
        /// <param name = "arguments">Arguments of <paramref name = "handler" />, when it is being invoked.</param>
        /// <param name = "handler">The delegate being added to the event, removed from the event, or invoked.</param>
        internal EventInterceptionArgs( object instance, Arguments arguments, Delegate handler )
            : base( instance )
        {
            this.Handler = handler;
            this.Arguments = arguments;
        }

        /// <summary>
        ///   Gets an interface that allows to invoke the next node in the chain of invocation of the intercepted method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='bindingProperty']/*" />
        /// </remarks>
        public abstract IEventBinding Binding { [DebuggerHidden]get; }

        /// <summary>
        ///   Gets the delegate being added, removed, or invoked.
        /// </summary>
        public Delegate Handler { [DebuggerHidden]get; [DebuggerHidden]private set; }


        /// <summary>
        ///   Gets the return value of the delegate.
        /// </summary>
        /// <remarks>
        ///   <para>This property is meaningful only during a delegate invocation (not during an addition or removal).</para>
        ///   <para>This property is typically set by the <see cref = "ProceedInvokeHandler" /> method. It is also legal for
        ///     an implementation of <see cref = "IEventInterceptionAspect.OnInvokeHandler" /> to change the value of this property.</para>
        /// </remarks>
        public object ReturnValue { [DebuggerHidden]get; [DebuggerHidden]set; }

        /// <summary>
        ///   Gets the event to which the current aspect has been applied.
        /// </summary>
        /// <remarks>
        ///   <note>
        ///     Using this property causes the aspect weaver to generate code that has non-trivial runtime overhead. Avoid using
        ///     this property whenever possible. One of the possible solution is to use compile-time initialization of
        ///     aspect instances and to make use of reflection only at build time.
        ///   </note>
        /// </remarks>
        public EventInfo Event { [DebuggerHidden]get; [DebuggerHidden]set; }

        /// <summary>
        ///   Gets the delegate arguments.
        /// </summary>
        /// <remarks>
        ///   <para>This property is meaningful only during a delegate invocation (not during an addition or removal).</para>
        ///   <para>This property is typically accessed by the <see cref = "ProceedInvokeHandler" /> method. Implementations of
        ///     <see cref = "IEventInterceptionAspect.OnInvokeHandler" /> can also get or change the value of this property.</para>
        /// </remarks>
        public Arguments Arguments { [DebuggerHidden]get; [DebuggerHidden]private set; }

        /// <summary>
        ///   Proceeds with adding the <see cref = "Delegate" /> to the event to which the current aspect. 
        ///   This method invokes the next handler in chain. 
        ///   It is typically invoked from the implementation of <see cref = "IEventInterceptionAspect.OnAddHandler" />.
        /// </summary>
        public abstract void ProceedAddHandler();

        /// <summary>
        ///   Adds a handler to the event by invoking the <c>Add</c> semantic of the next node in the chain of invocation.
        /// </summary>
        /// <param name = "handler">The handler to add to the event.</param>
        public abstract void AddHandler( Delegate handler );


        /// <summary>
        ///   Proceeds with removing the <see cref = "Delegate" /> from the event to which the current aspect. 
        ///   This method invokes the next handler in chain. 
        ///   It is typically invoked from the implementation of <see cref = "IEventInterceptionAspect.OnRemoveHandler" />.
        /// </summary>
        public abstract void ProceedRemoveHandler();

        /// <summary>
        ///   Removes a handler from the event by invoking the <c>Remove</c> semantic of the next node in the chain of invocation.
        /// </summary>
        /// <param name = "handler">Handler to be removed.</param>
        public abstract void RemoveHandler( Delegate handler );

        /// <summary>
        ///   Proceeds with invoking the <see cref = "Delegate" /> with the arguments specified in the <see cref = "Arguments" /> property.
        ///   The delegate may change the <see cref = "Arguments" /> and set the <see cref = "ReturnValue" />.
        ///   This method invokes the next handler in chain. 
        ///   It is typically invoked from the implementation of <see cref = "IEventInterceptionAspect.OnInvokeHandler" />.
        /// </summary>
        public abstract void ProceedInvokeHandler();

        /// <summary>
        ///   Invokes a handler by calling the <c>Invoke</c> semantic of the next node in the chain of invocation.
        /// </summary>
        /// <param name = "handler">Handler to be invoked.</param>
        /// <param name = "arguments">Arguments passed to the handler.</param>
        /// <returns>Return value of the handler.</returns>
        public abstract object InvokeHandler( Delegate handler, Arguments arguments );
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects.Internals;

#pragma warning disable CA2227 // Collection properties should be read only


namespace PostSharp.Aspects
{
    /// <summary>
    ///   Arguments of advices of aspect type <see cref = "MethodInterceptionAspect" />.
    /// </summary>
    /// <remarks>
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgs']/*" />
    /// </remarks>
    /// <seealso cref = "MethodInterceptionAspect" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class MethodInterceptionArgs : AdviceArgs
    {
        internal MethodInterceptionArgs( object instance, Arguments arguments )
            : base( instance )
        {
            this.Arguments = arguments;
        }

        /// <summary>
        ///   Gets an interface that allows to invoke the next node in the chain of invocation of the intercepted method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='bindingProperty']/*" />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public abstract IMethodBinding Binding { [DebuggerHidden]get; }

        /// <summary>
        ///   Gets or sets the return value of the method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public abstract object ReturnValue { [DebuggerHidden]get; [DebuggerHidden]set; }

        /// <summary>
        ///   Gets the method being executed.
        /// </summary>
        /// <remarks>
        ///   <para>If the executed method is generic or if its declaring type is generic,
        ///     the current property contains the generic instance being executed.</para>
        ///   <note>
        ///     Using this property causes the aspect weaver to generate code that has non-trivial runtime overhead. Avoid using
        ///     this property whenever possible. One of the possible solution is to use compile-time initialization of
        ///     aspect instances and to make use of reflection only at build time. See <see cref = "MethodLevelAspect.CompileTimeInitialize" />
        ///     for details.
        ///   </note>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        /// <seealso cref = "MethodLevelAspect.CompileTimeInitialize" />
        public MethodBase Method { [DebuggerHidden]get; [DebuggerHidden]set; }

        /// <summary>
        ///   Gets the list of arguments with which the method has been invoked.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public Arguments Arguments { [DebuggerHidden]get; [DebuggerHidden]protected set; }

        /// <summary>
        ///   Proceeds with invocation of the method that has been intercepted by calling the next node in the chain of invocation, 
        ///   passing the current <see cref = "Arguments" /> to that method and 
        ///   storing its return value into the property <see cref = "ReturnValue" />.
        /// </summary>
        public abstract void Proceed();

        /// <summary>
        ///   Invokes the method that has been intercepted by calling the next node in the chain of invocation with given arguments,
        ///   without affecting the property <see cref = "ReturnValue" />.
        /// </summary>
        /// <param name = "arguments">Arguments passed to the intercepted method.</param>
        /// <returns>Value returned by the intercepted method.</returns>
        public abstract object Invoke( Arguments arguments );

#if ASYNCAWAIT

        /// <summary>
        /// Determines whether the intercepted method is <c>async</c>, and therefore whether the <see cref="AsyncBinding"/> property
        /// and <see cref="ProceedAsync"/> method are available.
        /// </summary>
        public abstract bool IsAsync { get; }

        /// <summary>
        ///   Gets an interface that allows to invoke asynchronously the next node in the chain of invocation of the intercepted method.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='bindingProperty']/*" />
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public abstract IAsyncMethodBinding AsyncBinding { [DebuggerHidden] get; }
        
        /// <summary>
        ///   Proceeds asynchronously with invocation of the method that has been intercepted by calling the next node in the chain of invocation, 
        ///   passing the current <see cref = "Arguments" /> to that method and 
        ///   storing its return value into the property <see cref = "ReturnValue" /> upon the completion of the intercepted async method.
        /// </summary>
        public abstract MethodInterceptionProceedAwaitable ProceedAsync();

        /// <summary>
        ///   Invokes asynchronously the method that has been intercepted by calling the next node in the chain of invocation with given arguments,
        ///   without affecting the property <see cref = "ReturnValue" />.
        /// </summary>
        /// <param name = "arguments">Arguments passed to the intercepted method.</param>
        /// <returns>The value that can be awaited to get the result of the intercepted method's invocation.</returns>
        public abstract MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments );
#endif
    }

#if ASYNCAWAIT
#endif
}
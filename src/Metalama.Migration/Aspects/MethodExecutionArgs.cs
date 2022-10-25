using System;
using System.Diagnostics;
using System.Reflection;

#pragma warning disable CA2227 // Collection properties should be read only

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Arguments of advices of aspects of type <see cref = "OnMethodBoundaryAspect" /> and <see cref = "OnExceptionAspect" />
    /// </summary> 
    /// <remarks>
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgs']/*" />
    /// </remarks>
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public class MethodExecutionArgs : AdviceArgs
    {
        /// <exclude />
        public MethodExecutionArgs( object instance, Arguments arguments ) : base( instance )
        {
            Arguments = arguments;
        }

        /// <summary>
        ///   Gets the method being executed.
        /// </summary>
        /// <note>
        ///    As a result of weaving optimizations, this property may be seen <c>null</c> when inspecting its value using a debugger.
        ///    Therefore, you may want to disable aspect optimizer
        /// </note>
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
        public MethodBase Method { get; }

        /// <summary>
        ///   Gets the arguments with which the method has been invoked.
        /// </summary>
        /// <remarks>
        ///   <note>The property setter should never be used in user code.</note>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public Arguments Arguments { get; }

        /// <summary>
        ///   Gets or sets the method return value.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     You can modify the return value only when the join point is located
        ///     after a method execution (<see cref = "OnMethodBoundaryAspect.OnSuccess" />,
        ///     <see cref = "OnMethodBoundaryAspect.OnException" /> or <see cref = "OnMethodBoundaryAspect.OnExit" />,
        ///     or in case you force the method to exit using the <see cref = "FlowBehavior" /> property.
        ///   </para>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        /// <note>
        ///    This property must not be accessed when the aspect is applied to a state machine or if the method returns a reference ("ref return").
        /// </note>
        /// <note>
        ///   When a method returns a null <see cref="System.Threading.Tasks.Task"/>, this property is equal to <see cref="NullTaskSentinel"/>.<see cref="NullTaskSentinel.Instance"/>
        ///   and its value cannot be modified.
        /// </note>
        public object ReturnValue { get; set; }

        /// <summary>
        /// Gets or sets the value yielded by the iterator method.
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     This property is only available inside the <see cref="IOnStateMachineBoundaryAspect.OnYield"/> advice
        ///     when the current method is an iterator method.
        ///   </para>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        /// <seealso cref="IOnStateMachineBoundaryAspect"/>
        public object YieldValue { get; set; }

        /// <summary>
        ///   Gets or sets the exception thrown by the target method.
        /// </summary>
        /// <value>An <see cref = "Exception" />, or <c>null</c> if the method is exiting normally.</value>
        /// <remarks>
        ///   <para>This property is only available inside the <see cref="IOnMethodBoundaryAspect.OnException"/> and <see cref="IOnExceptionAspect.OnException"/> advices.</para>
        ///   <para>You can replace the exception by setting this property and also setting <see cref="FlowBehavior"/> to <see cref="Aspects.FlowBehavior.ThrowException"/>. You can also throw a new exception from the advice if you need to replace the current exception.</para>
        /// </remarks>
        public Exception Exception { get; set; }

        /// <summary>
        ///   Determines the control flow of the target method once the advice is exited.
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        ///    When this advice is applied to a state machine, you only have limited flow behavior options available. See documentation
        /// for <see cref="Aspects.FlowBehavior"/> for details.
        /// </remarks>
        public FlowBehavior FlowBehavior { get; set; }

        /// <summary>
        ///   User-defined state information whose lifetime is linked to the
        ///   current method execution. Aspects derived from <see cref = "IOnMethodBoundaryAspect" />
        ///   should use this property to save state information between
        ///   different events (<see cref = "IOnMethodBoundaryAspect.OnEntry" />,
        ///   <see cref = "IOnMethodBoundaryAspect.OnExit" /> and <see cref = "IOnMethodBoundaryAspect.OnException" />).
        /// </summary>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public object MethodExecutionTag { get; set; }
    }
}
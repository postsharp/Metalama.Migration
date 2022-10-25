using System.Diagnostics;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Base class for arguments of all advices.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public class AdviceArgs
    {
        static AdviceArgs()
        {
            // TODO: remove this after we have a different way of forcing DebuggerInterop type to load during debugging.
            DebuggerInterop.Dummy();
        }

        /// <summary>
        ///   Initializes a new <see cref = "AdviceArgs" />.
        /// </summary>
        /// <param name = "instance">The instance related to the advice invocation, or
        ///   <c>null</c> if the advice is associated to a static element of code.</param>
        public AdviceArgs( object instance ) { }

        protected AdviceArgs() { }

        /// <summary>
        ///   Gets or sets the object instance on which the method is being executed.
        /// </summary>
        /// <remarks> 
        ///   <para>This may be set by user code only when the instance is a value type.
        ///   As usual, user code is responsible for setting an object of the
        ///   right type.</para> 
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public object Instance { get; }

        /// <summary>
        ///   Gets the <see cref="DeclarationIdentifier"/> of the declaration to which the
        ///   advice has been applied.
        /// </summary>
        /// <remarks>
        ///   <para>For usage information, see the remarks of the <see cref="DeclarationIdentifier"/> type documentation.</para>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgsProperty']/*" />
        /// </remarks>
        public DeclarationIdentifier DeclarationIdentifier { get; }
    }
}
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Represents an advise that introduces an interface into the target class. The interface must be implemented by the aspect class.
    /// </summary>
    /// <seealso cref="IAdviceProvider"/>
    /// <seealso cref="IntroduceInterfaceAttribute"/>
    public sealed class IntroduceInterfaceAdviceInstance : AdviceInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntroduceInterfaceAdviceInstance"/> class.
        /// </summary>
        /// <param name="interfaceType">Interface to introduce to the target class. Must be implemented by the aspect class itself.</param>
        /// <param name="overrideAction">Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.</param>
        /// <param name="ancestorOverrideAction"> Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.</param>
        public IntroduceInterfaceAdviceInstance(
            Type interfaceType,
            InterfaceOverrideAction overrideAction = InterfaceOverrideAction.Fail,
            InterfaceOverrideAction ancestorOverrideAction = InterfaceOverrideAction.Fail )
        {
            if (interfaceType == null)
            {
                throw new ArgumentNullException( nameof(interfaceType) );
            }

            InterfaceType = interfaceType;
            OverrideAction = overrideAction;
            AncestorOverrideAction = ancestorOverrideAction;
        }

        /// <summary>
        /// Gets the interface to be introduced into the target class.
        /// </summary>
        public Type InterfaceType { get; }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "AncestorOverrideAction" />
        public InterfaceOverrideAction OverrideAction { get; }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "OverrideAction" />
        public InterfaceOverrideAction AncestorOverrideAction { get; }

        /// <inhericdoc />
        public override object MasterAspectMember { get; }
    }
}
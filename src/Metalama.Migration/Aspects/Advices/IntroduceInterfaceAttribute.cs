using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied to an aspect class, specifies that the aspect should
    ///   introduce a given interface into the type to which the aspect is applied.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoIntroduceInterface']/*" />
    /// <remarks>
    /// <para>The introduced interface will be implemented explicitly by the type to which the aspect is applied.</para>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true )]
    public sealed class IntroduceInterfaceAttribute : Advice
    {
        /// <summary>
        ///   Initializes a new <see cref = "IntroduceInterfaceAttribute" />.
        /// </summary>
        /// <param name = "interfaceType">Interface that should be introduced into the types
        ///   to which the aspect is applied.</param>
        public IntroduceInterfaceAttribute( Type interfaceType )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "AncestorOverrideAction" />
        public InterfaceOverrideAction OverrideAction { get; set; }

        /// <summary>
        ///   Specifies the action (<see cref = "InterfaceOverrideAction.Fail" /> or <see cref = "InterfaceOverrideAction.Ignore" />)
        ///   to be overtaken when an <i>ancestor</i> of the interface specified in the constructor of this custom attribute
        ///   is already implemented by the type to which the current aspect is applied.
        /// </summary>
        /// <seealso cref = "OverrideAction" />
        public InterfaceOverrideAction AncestorOverrideAction { get; set; }
    }
}
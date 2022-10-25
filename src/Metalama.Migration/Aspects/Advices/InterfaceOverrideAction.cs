// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Enumeration of actions to be overtaken when an interface that should be introduced into a type is already
    ///   implemented by that type.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <seealso cref = "IntroduceInterfaceAttribute" />
    public enum InterfaceOverrideAction
    {
        /// <summary>
        ///   <see cref = "Fail" />.
        /// </summary>
        Default = 0,

        /// <summary>
        ///   Fails and emits an error message.
        /// </summary>
        Fail = Default,

        /// <summary>
        ///   Silently ignore this interface (does not introduce it).
        /// </summary>
        Ignore
    }
}
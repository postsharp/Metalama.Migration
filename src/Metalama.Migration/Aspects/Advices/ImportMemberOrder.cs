// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code.Invokers;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, equivalent to <see cref="InvokerOrder"/>. You can pass an <see cref="InvokerOrder"/> to the <see cref="IInvokerFactory{T}"/>.<see cref="IInvokerFactory{T}.GetInvoker"/>
    /// method.
    /// </summary>
    public enum ImportMemberOrder
    {
        /// <summary>
        /// Equivalent to <see cref="InvokerOrder.Default"/>.
        /// </summary>
        Default,

        /// <summary>
        /// Equivalent to <see cref="InvokerOrder.Base"/>.
        /// </summary>
        BeforeIntroductions,

        /// <summary>
        /// Equivalent to <see cref="InvokerOrder.Default"/>.
        /// </summary>
        AfterIntroductions = Default
    }
}
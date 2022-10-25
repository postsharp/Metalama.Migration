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
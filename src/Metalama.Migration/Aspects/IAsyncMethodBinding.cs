// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Interface through which a method-level aspect or advice can
    ///   asynchronously invoke the next node in the chain of invocation.
    /// </summary>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectBindings']/*" />
    [Internal]
    public interface IAsyncMethodBinding : IMethodBinding
    {
        /// <summary>
        ///   Invokes asynchronously the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance on which the method should be invoked (<c>null</c> if the method is static).</param>
        /// <param name = "arguments">Method arguments.</param>
        /// <returns>The value that can be awaited to get the result of the underlying method's invocation.
        /// </returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        MethodBindingInvokeAwaitable InvokeAsync( ref object instance, Arguments arguments );
    }
}
#endif

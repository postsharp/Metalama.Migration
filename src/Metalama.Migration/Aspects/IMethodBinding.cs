// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Interface through which a method-level aspect or advice can
    ///   invoke the next node in the chain of invocation.
    /// </summary>
    /// <seealso cref="PostSharp.Aspects.Advices.ImportMemberAttribute"/>
    /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectBindings']/*" />
    [Internal]
    public interface IMethodBinding
    {
        /// <summary>
        ///   Invokes the next node in the chain of invocation.
        /// </summary>
        /// <param name = "instance">Target instance on which the method should be invoked (<c>null</c> if the method is static).</param>
        /// <param name = "arguments">Method arguments.</param>
        /// <returns>Return value of the method.</returns>
        /// <remarks>
        ///   <include file = "Documentation.xml" path = "/documentation/section[@name='binding']/*" />
        /// </remarks>
        object Invoke( ref object instance, Arguments arguments );
    }


}
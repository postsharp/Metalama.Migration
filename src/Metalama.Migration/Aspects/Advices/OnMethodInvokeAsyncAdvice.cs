// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if ASYNCAWAIT

using System;
using PostSharp.Aspects.Internals;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method of an aspect class, specifies
    ///   that this method is an advice having the same semantics as <see cref = "IAsyncMethodInterceptionAspect.OnInvokeAsync" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "IAsyncMethodInterceptionAspect.OnInvokeAsync" />. However, it can be static.
    ///   </para>
    /// </remarks>
    /// <seealso cref = "MethodInterceptionAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    [RequiresMethodInterceptionAdviceAnalysis]
    [RequiresDebuggerEnhancement( DebuggerStepOverAspectBehavior.RunToTarget )]
    public sealed class OnMethodInvokeAsyncAdvice : OnMethodInvokeBaseAdvice
    {
    }
}

#endif
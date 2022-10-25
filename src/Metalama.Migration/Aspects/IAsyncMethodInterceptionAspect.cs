// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#if ASYNCAWAIT
using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using System.Threading.Tasks;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on a method, intercepts invocations of this method.
    ///   Includes semantics for both async and non-async method interception.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "MethodInterceptionAspect" /> for details.
    /// </remarks>
    /// <see cref = "MethodInterceptionAspect" />
    /// <see cref = "MethodInterceptionAspectConfiguration" />
    /// <see cref = "MethodInterceptionAspectConfigurationAttribute" />
    [HasInheritedAttribute]
    public interface IAsyncMethodInterceptionAspect : IMethodInterceptionAspect
    {
        /// <summary>
        ///   Method invoked <i>instead</i> of the method to which the aspect has been applied.
        /// </summary>
        /// <param name = "args">Advice arguments.</param>
        /// <remarks>
        ///   <para>The implementation of <see cref = "OnInvokeAsync" /> may invoke <see cref = "MethodInterceptionArgs.ProceedAsync" />, may schedule it for invocation from another thread, or
        ///     may completely skip its invocation. Alternatively, it may use <see cref = "MethodInterceptionArgs.Binding" />. Before returning to the caller,
        ///     the <see cref = "OnInvokeAsync" /> method must set the return value (property <see cref = "MethodInterceptionArgs.ReturnValue" />),
        ///     otherwise the target method may fail with a <see cref = "NullReferenceException" />. It is normally set by calling <see cref = "MethodInterceptionArgs.ProceedAsync" />.</para>
        ///   <para>
        ///     If semantic advising applies to a method and the method is an async method or returns a <see cref="Task"/>, then <see cref="OnInvokeAsync" /> is called for that method instead of <see cref="IMethodInterceptionAspect.OnInvoke"/>.
        ///   </para>
        /// </remarks>
        /// <seealso cref = "MethodInterceptionArgs" />
        [RequiresMethodInterceptionAdviceAnalysis, RequiresDebuggerEnhancement( DebuggerStepOverAspectBehavior.RunToTarget ), HasInheritedAttribute]
        System.Threading.Tasks.Task OnInvokeAsync( MethodInterceptionArgs args );
    }
}
#endif

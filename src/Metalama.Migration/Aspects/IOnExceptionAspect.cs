// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on a method,
    ///   defines an exception handler around the whole method body
    ///   and lets the implementation of this interface handle the exception.
    /// </summary>
    /// <remarks>
    ///   <para>See <see cref = "OnExceptionAspect" /> for details.</para>
    /// </remarks>
    /// <seealso cref = "OnExceptionAspect" />
    /// <seealso cref = "OnExceptionAspectConfiguration" />
    /// <seealso cref = "OnExceptionAspectConfigurationAttribute" />
    [HasInheritedAttribute]
    public interface IOnExceptionAspect : IMethodLevelAspect
    {
        /// <summary>
        ///   Method executed <b>after</b> the body of methods to which this aspect is applied,
        ///   in case that the method failed with an exception (i.e., in a <c>catch</c> block).
        /// </summary>
        /// <param name = "args">Advice arguments.</param>
        [RequiresMethodExecutionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.StepOut), HasInheritedAttribute]
        void OnException( MethodExecutionArgs args );
    }
}
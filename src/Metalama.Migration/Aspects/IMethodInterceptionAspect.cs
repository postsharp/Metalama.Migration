using System;
using PostSharp.Aspects.Configuration;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on a method, intercepts invocations of this method.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "MethodInterceptionAspect" /> for details.
    /// </remarks>
    /// <see cref = "MethodInterceptionAspect" />
    /// <see cref = "MethodInterceptionAspectConfiguration" />
    /// <see cref = "MethodInterceptionAspectConfigurationAttribute" />
    public interface IMethodInterceptionAspect : IMethodLevelAspect
    {
        /// <summary>
        ///   Method invoked <i>instead</i> of the method to which the aspect has been applied.
        /// </summary>
        /// <param name = "args">Advice arguments.</param>
        /// <remarks>
        ///   <para>The implementation of <see cref = "OnInvoke" /> may invoke <see cref = "MethodInterceptionArgs.Proceed" />, may schedule it for invocation from another thread, or
        ///     may completely skip its invocation. Alternatively, it may use <see cref = "MethodInterceptionArgs.Binding" />. Before returning to the caller, the <see cref = "OnInvoke" /> method must set the return value (property <see cref = "MethodInterceptionArgs.ReturnValue" />)
        ///     and all output arguments (property <see cref = "MethodInterceptionArgs.Arguments" />), otherwise the target method may fail with a <see cref = "NullReferenceException" />. These
        ///     are normally set by calling <see cref = "MethodInterceptionArgs.Proceed" />.</para>
        /// </remarks>
        /// <seealso cref = "MethodInterceptionArgs" />
        void OnInvoke( MethodInterceptionArgs args );
    }
}
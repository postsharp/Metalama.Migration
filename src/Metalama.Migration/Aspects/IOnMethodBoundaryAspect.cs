using PostSharp.Aspects.Configuration;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of <see cref = "OnMethodBoundaryAspect" />.
    /// </summary>
    /// <remarks>
    ///   <para>See <see cref = "OnMethodBoundaryAspect" /> for details.</para>
    /// </remarks>
    /// <seealso cref = "OnMethodBoundaryAspect" />
    /// <seealso cref = "OnMethodBoundaryAspectConfiguration" />
    /// <seealso cref = "OnMethodBoundaryAspectConfigurationAttribute" />
    public interface IOnMethodBoundaryAspect : IMethodLevelAspect
    {
        /// <summary>
        ///   Method executed <b>before</b> the body of methods to which this aspect is applied.
        /// </summary>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed, which are its arguments, and how should the execution continue
        ///   after the execution of <see cref = "OnEntry" />.</param>
        /// <remarks>
        ///   If the aspect is applied to a constructor, the current method is invoked
        ///   after the <c>this</c> pointer has been initialized, that is, after
        ///   the base constructor has been called.
        /// </remarks>
        void OnEntry( MethodExecutionArgs args );

        /// <summary>
        ///   Method executed <b>after</b> the body of methods to which this aspect is applied,
        ///   even when the method exists with an exception (this method is invoked from
        ///   the <c>finally</c> block).
        /// </summary>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed and which are its arguments.</param>
        void OnExit( MethodExecutionArgs args );

        /// <summary>
        ///   Method executed <b>after</b> the body of methods to which this aspect is applied,
        ///   but only when the method successfully returns (i.e. when no exception flies out
        ///   the method.).
        /// </summary>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed and which are its arguments.</param>
        void OnSuccess( MethodExecutionArgs args );

        /// <summary>
        ///   Method executed <b>after</b> the body of methods to which this aspect is applied,
        ///   in case that the method resulted with an exception.
        /// </summary>
        /// <param name = "args">Event arguments specifying which method
        ///   is being executed and which are its arguments.</param>
        void OnException( MethodExecutionArgs args );
    }
}
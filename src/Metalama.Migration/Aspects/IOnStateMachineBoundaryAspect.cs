using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// This feature is not implemented in Metalama and there is no workaround.
    /// </summary>
    public interface IOnStateMachineBoundaryAspect : IOnMethodBoundaryAspect
    {
        /// <summary>
        /// This feature is not implemented in Metalama and there is no workaround.
        /// </summary>
        [Obsolete( "", true )]
        void OnResume( MethodExecutionArgs args );

        /// <summary>
        /// This feature is not implemented in Metalama and there is no workaround.
        /// </summary>
        [Obsolete( "", true )]
        void OnYield( MethodExecutionArgs args );
    }
}
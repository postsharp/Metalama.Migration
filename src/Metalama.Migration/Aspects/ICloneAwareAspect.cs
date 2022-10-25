using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no built-in support for cloning in Metalama at the moment.
    /// </summary>
    public interface ICloneAwareAspect : IInstanceScopedAspect
    {
        /// <summary>
        /// There is no built-in support for cloning in Metalama at the moment.
        /// </summary>
        [Obsolete( "", true )]
        void OnCloned( ICloneAwareAspect source );
    }
}
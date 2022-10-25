using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/> and write your own try/catch block.
    /// </summary>
    public interface IOnExceptionAspect : IMethodLevelAspect
    {
        /// <summary>
        /// Implement <see cref="OverrideMethodAspect.OverrideMethod"/> and write your own try/catch block.
        /// </summary>
        void OnException( MethodExecutionArgs args );
    }
}
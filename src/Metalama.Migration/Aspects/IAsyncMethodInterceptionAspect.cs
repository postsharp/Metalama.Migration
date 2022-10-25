using System.Threading.Tasks;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    public interface IAsyncMethodInterceptionAspect : IMethodInterceptionAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="OverrideMethodAspect.OverrideAsyncMethod"/>.
        /// </summary>
        Task OnInvokeAsync( MethodInterceptionArgs args );
    }
}
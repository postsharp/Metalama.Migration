using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, a binding was a run-time object that allowed the run-time code of the aspect to call the target code. In Metalama, aspects no longer
    /// have run-time code. Instead, they have templates that are expanded at compile time and generate run-time code. Templates can generate run-time code
    /// that accesses target code using dynamic code or invokers. For methods, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethod.Invokers"/>.
    /// </summary>
    public interface IAsyncMethodBinding : IMethodBinding
    {
        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Method"/>.<see cref="IMethod.Invokers"/>.
        /// </summary>
        MethodBindingInvokeAwaitable InvokeAsync( ref object instance, Arguments arguments );
    }
}
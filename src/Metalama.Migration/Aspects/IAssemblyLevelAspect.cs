#pragma warning disable CA1040 // Avoid empty interfaces

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="ICompilation"/>.
    /// </summary>
    public interface IAssemblyLevelAspect : IAspect { }
}
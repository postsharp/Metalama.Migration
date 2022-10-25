using System.Reflection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="ICompilation"/>.
    /// </summary>
    public interface IAssemblyLevelAspectBuildSemantics : IAspect
    {
        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo );
    }
}
using System.Reflection;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    public interface IAssemblyLevelAspectBuildSemantics : IAspect
    {
        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo );
    }
}
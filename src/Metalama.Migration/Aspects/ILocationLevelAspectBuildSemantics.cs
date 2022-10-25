using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="IFieldOrProperty"/>.
    /// </summary>
    public interface ILocationLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        void CompileTimeInitialize( LocationInfo targetLocation, AspectInfo aspectInfo );
    }
}
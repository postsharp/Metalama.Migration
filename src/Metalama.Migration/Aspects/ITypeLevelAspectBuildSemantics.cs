using System;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="INamedType"/>.
    /// </summary>
    public interface ITypeLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        void CompileTimeInitialize( Type type, AspectInfo aspectInfo );
    }
}
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Compile-time semantics of <see cref = "ITypeLevelAspect" />.
    /// </summary>
    public interface ITypeLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked
        ///   before any other build-time method.
        /// </summary>
        /// <param name = "type">Type to which the current aspect is applied</param>
        /// <param name = "aspectInfo">Reserved for future usage.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void CompileTimeInitialize( Type type, AspectInfo aspectInfo );
    }
}
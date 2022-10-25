using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Compile-time semantics of <see cref = "IMethodLevelAspect" />.
    /// </summary>
    /// <see cref = "MethodLevelAspect" />
    /// <see cref = "IMethodLevelAspect" />
    public interface IMethodLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked
        ///   before any other build-time method.
        /// </summary>
        /// <param name = "method">Method to which the current aspect is applied</param>
        /// <param name = "aspectInfo">Reserved for future usage.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo );
    }
}
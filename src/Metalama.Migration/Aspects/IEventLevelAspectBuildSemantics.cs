using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Build-time semantics of aspects that can be applied on events.
    /// </summary>
    /// <seealso cref = "EventLevelAspect" />
    /// <seealso cref = "IEventLevelAspect" />
    public interface IEventLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked
        ///   before any other build-time method.
        /// </summary>
        /// <param name = "targetEvent">Event to which the current aspect is applied</param>
        /// <param name = "aspectInfo">Reserved for future usage.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void CompileTimeInitialize( EventInfo targetEvent, AspectInfo aspectInfo );
    }
}
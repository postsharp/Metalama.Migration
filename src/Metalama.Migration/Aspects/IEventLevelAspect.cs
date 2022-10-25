using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects that can be applied on events.
    /// </summary>
    /// <seealso cref = "EventLevelAspect" />
    /// <seealso cref = "IEventLevelAspectBuildSemantics" />
    public interface IEventLevelAspect : IAspect
    {
        /// <summary>
        ///   Initializes the current aspect.
        /// </summary>
        /// <param name = "eventInfo">Event to which the current aspect is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( EventInfo eventInfo );
    }
}
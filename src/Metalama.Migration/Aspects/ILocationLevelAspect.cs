using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects defined on a field, property, or parameter.
    /// </summary>
    public interface ILocationLevelAspect : IAspect
    {
        /// <summary>
        ///   Initializes the current aspect.
        /// </summary>
        /// <param name = "locationInfo">Location to which the current aspect is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( LocationInfo locationInfo );
    }
}
using System;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Run-time semantics of aspects applied to types.
    /// </summary>
    /// <seealso cref = "ITypeLevelAspectBuildSemantics" />
    public interface ITypeLevelAspect : IAspect
    {
        /// <summary>
        ///   Initializes the current aspect.
        /// </summary>
        /// <param name = "type">Type to which the current aspect is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( Type type );
    }
}
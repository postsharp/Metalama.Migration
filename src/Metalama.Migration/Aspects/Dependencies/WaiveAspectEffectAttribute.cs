using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Declares that the aspect class or advice to which this custom attribute is applied
    ///   is exempt of a given effect.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "AspectEffectDependencyAttribute" /> for details about effects.
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    /// <remarks>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method )]
    public sealed class WaiveAspectEffectAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "WaiveAspectEffectAttribute" /> declaring that
        ///   the aspect class or advice to which this custom attribute is applied has
        ///   no effect at all.
        /// </summary>
        public WaiveAspectEffectAttribute() { }

        /// <summary>
        ///   Initializes a new <see cref = "WaiveAspectEffectAttribute" /> declaring that
        ///   the aspect class or advice to which this custom attribute is applied is
        ///   exempt of the specified effects.
        /// </summary>
        /// <param name = "effects">List of effects of which the aspect class or advice
        ///   to which this custom attribute is applied is guaranteed to be exempt.</param>
        public WaiveAspectEffectAttribute( params string[] effects )
        {
            Effects = effects;
        }

        /// <summary>
        /// Gets the list of effects of which the aspect class or advice
        /// to which this custom attribute is applied is guaranteed to be exempt.
        /// </summary>
        public string[] Effects { get; }
    }
}
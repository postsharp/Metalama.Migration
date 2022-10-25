using System;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect effects are not supported in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method )]
    public sealed class WaiveAspectEffectAttribute : Attribute
    {
        public WaiveAspectEffectAttribute() { }

        public WaiveAspectEffectAttribute( params string[] effects )
        {
            Effects = effects;
        }

        public string[] Effects { get; }
    }
}
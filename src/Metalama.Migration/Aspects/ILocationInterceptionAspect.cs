using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideFieldOrPropertyAspect"/>.
    /// </summary>
    public interface ILocationInterceptionAspect : ILocationLevelAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="OverrideFieldOrPropertyAspect.OverrideProperty"/>.
        /// </summary>
        void OnGetValue( LocationInterceptionArgs args );

        /// <summary>
        /// In Metalama, implement <see cref="OverrideFieldOrPropertyAspect.OverrideProperty"/>.
        /// </summary>
        void OnSetValue( LocationInterceptionArgs args );
    }
}
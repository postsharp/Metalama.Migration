using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Exposes the PostSharp version with which the current version of PostSharp should be backward compatible.
    /// </summary>
    public interface ICompatibilityLevelService : IService
    {
        /// <summary>
        /// Gets the PostSharp version with which the current version of PostSharp should be backward compatible.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Some breaking changes may ignore this property.
        /// </para>
        /// </remarks>
        Version CompatibilityLevel { get; }
    }
}
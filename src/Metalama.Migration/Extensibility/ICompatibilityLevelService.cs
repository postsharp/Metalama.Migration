using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface ICompatibilityLevelService : IService
    {
        Version CompatibilityLevel { get; }
    }
}
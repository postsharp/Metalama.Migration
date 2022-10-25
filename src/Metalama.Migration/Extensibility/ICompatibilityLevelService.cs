using System;

namespace PostSharp.Extensibility
{
    public interface ICompatibilityLevelService : IService
    {
        Version CompatibilityLevel { get; }
    }
}
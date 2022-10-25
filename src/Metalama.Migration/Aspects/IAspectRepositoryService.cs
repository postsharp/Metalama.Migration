using System;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    public interface IAspectRepositoryService : IService
    {
        IAspectInstance[] GetAspectInstances( object declaration );

        bool HasAspect( object declaration, Type aspectType );

        event EventHandler AspectDiscoveryCompleted;
    }
}
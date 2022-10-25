using System.Collections.Generic;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    public interface IAspectProvider : IAspect, IService
    {
        IEnumerable<AspectInstance> ProvideAspects( object targetElement );
    }
}
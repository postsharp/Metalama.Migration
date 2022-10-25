using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    [InternalImplement]
    public interface IAspectInstance
    {
        AspectConfiguration AspectConfiguration { get; }

        ObjectConstruction AspectConstruction { get; }

        IAspect Aspect { get; }

        Type AspectType { get; }
    }
}
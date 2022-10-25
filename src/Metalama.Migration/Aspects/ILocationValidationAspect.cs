using System;
using PostSharp.Reflection;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    public interface ILocationValidationAspect : IAspect { }

    public interface ILocationValidationAspect<T> : ILocationValidationAspect
    {
        Exception ValidateValue( T value, string locationName, LocationKind locationKind, LocationValidationContext context );
    }
}
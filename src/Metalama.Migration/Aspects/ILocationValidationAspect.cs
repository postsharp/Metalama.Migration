using System;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="ContractAspect"/>.
    /// </summary>
    public interface ILocationValidationAspect : IAspect { }

    /// <summary>
    /// In Metalama, use <see cref="ContractAspect"/>.
    /// </summary>
    public interface ILocationValidationAspect<T> : ILocationValidationAspect
    {
        /// <summary>
        /// In Metalama, implement <see cref="ContractAspect.Validate"/>.
        /// </summary>
        Exception ValidateValue( T value, string locationName, LocationKind locationKind, LocationValidationContext context );
    }
}
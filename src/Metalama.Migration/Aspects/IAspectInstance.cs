using System;
using PostSharp.Aspects.Configuration;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Use <see cref="Metalama.Framework.Aspects.IAspectInstance"/>.
    /// </summary>
    [InternalImplement]
    public interface IAspectInstance
    {
        /// <summary>
        /// There is no aspect configuration in Metalama.
        /// </summary>
        AspectConfiguration AspectConfiguration { get; }

        /// <summary>
        /// Use <see cref="Metalama.Framework.Aspects.IAspectInstance.Predecessors"/>/
        /// </summary>
        ObjectConstruction AspectConstruction { get; }

        IAspect Aspect { get; }

        Type AspectType { get; }
    }
}
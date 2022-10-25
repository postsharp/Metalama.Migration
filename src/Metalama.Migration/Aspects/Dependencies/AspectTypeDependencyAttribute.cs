using System;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, use <see cref="AspectOrderAttribute"/> to specify order dependencies (typically one attribute per aspect library).
    /// The other kinds of dependencies are not supported in Metalama.
    /// </summary>
    public sealed class AspectTypeDependencyAttribute : AspectDependencyAttribute
    {
        public AspectTypeDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            Type aspectType )
            : base( action, position )
        {
            AspectType = aspectType;
        }

        public AspectTypeDependencyAttribute( AspectDependencyAction action, Type aspectType )
            : base( action )
        {
            AspectType = aspectType;
        }

        public Type AspectType { get; }
    }
}
using System;

namespace PostSharp.Aspects.Dependencies
{
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
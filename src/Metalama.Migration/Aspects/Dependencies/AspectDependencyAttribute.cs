using System;

namespace PostSharp.Aspects.Dependencies
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true, Inherited = true )]
    public abstract class AspectDependencyAttribute : Attribute
    {
        protected AspectDependencyAttribute( AspectDependencyAction action )
        {
            Action = action;
        }

        protected AspectDependencyAttribute( AspectDependencyAction action, AspectDependencyPosition position )
        {
            Action = action;
            Position = position;
        }

        public AspectDependencyAction Action { get; }

        public AspectDependencyPosition Position { get; }

        public AspectDependencyTarget Target;

        public bool IsWarning { get; set; }

        public Type TargetType { get; set; }
    }
}
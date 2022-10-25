using System;
using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, use <see cref="AspectOrderAttribute"/> to specify order dependencies (typically one attribute per aspect library).
    /// The other kinds of dependencies are not supported in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true )]
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
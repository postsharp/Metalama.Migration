// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect effects are not supported in Metalama.
    /// </summary>
    public sealed class AspectEffectDependencyAttribute : AspectDependencyAttribute
    {
        public AspectEffectDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string effect )
            : base( action, position )
        {
            this.Effect = effect;
        }

        public AspectEffectDependencyAttribute( AspectDependencyAction action, string effect )
            : base( action )
        {
            this.Effect = effect;
        }

        public string Effect { get; }
    }
}
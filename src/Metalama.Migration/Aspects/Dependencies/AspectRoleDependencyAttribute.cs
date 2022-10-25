// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// Aspect roles are not supported in Metalama.
    /// </summary>
    public sealed class AspectRoleDependencyAttribute : AspectDependencyAttribute
    {
        public AspectRoleDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string role )
            : base( action, position )
        {
            this.Role = role;
        }

        public AspectRoleDependencyAttribute( AspectDependencyAction action, string role )
            : base( action )
        {
            this.Role = role;
        }

        public string Role { get; }
    }
}
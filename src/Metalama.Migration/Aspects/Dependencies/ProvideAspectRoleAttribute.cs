using System;

namespace PostSharp.Aspects.Dependencies
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true )]
    public sealed class ProvideAspectRoleAttribute : AspectDependencyAttribute
    {
        public ProvideAspectRoleAttribute( string role ) : base( AspectDependencyAction.None )
        {
            Role = role;
        }

        public string Role { get; }
    }
}
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
            Role = role;
        }

        public AspectRoleDependencyAttribute( AspectDependencyAction action, string role )
            : base( action )
        {
            Role = role;
        }

        public string Role { get; }
    }
}
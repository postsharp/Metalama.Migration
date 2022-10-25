namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Specifies an aspect dependency matching aspects or advices that are a part of a given role.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     A role describes what the aspect actually does. A list of standard roles is available on the class
    ///     <see cref = "StandardRoles" />. Aspect vendors are encouraged to enroll their aspects in one of these
    ///     roles whenever it makes sense, and to document the other roles they have used.
    ///   </para>
    ///   <para>An aspect or advice can be enrolled in a role by using the <see cref = "ProvideAspectRoleAttribute" />
    ///     custom attribute.
    ///   </para>
    /// </remarks>/// <seealso cref = "ProvideAspectRoleAttribute" />
    /// <seealso cref = "StandardRoles" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class AspectRoleDependencyAttribute : AspectDependencyAttribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "AspectRoleDependencyAttribute" /> and specifies a position.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "position">Dependency position.</param>
        /// <param name = "role">Role.</param>
        public AspectRoleDependencyAttribute(
            AspectDependencyAction action,
            AspectDependencyPosition position,
            string role )
            : base( action, position )
        {
            Role = role;
        }

        /// <summary>
        ///   Initializes a new <see cref = "AspectEffectDependencyAttribute" /> without specifying the position,
        ///   implicitly set to <see cref = "AspectDependencyPosition.Any" />.
        /// </summary>
        /// <param name = "action">Dependency action.</param>
        /// <param name = "role">Role.</param>
        public AspectRoleDependencyAttribute( AspectDependencyAction action, string role )
            : base( action )
        {
            Role = role;
        }

        /// <summary>
        ///   Gets the role that the aspects or advices must be a part of in order to match the current dependency.
        /// </summary>
        public string Role { get; }
    }
}
using System;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Constraints
{
    /// <summary>
    /// <see cref="ReferentialConstraint"/> that, when applied on a declaration, limits the scope (namespace or type) in which this declaration 
    /// can be used. This constraint is useful to isolate several components from each other, even if they are implemented in
    /// the same assembly. The <i>ComponentInternal</i> constraint sets the visibility of a declaration between <c>internal</c> and <c>private</c>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public sealed class ComponentInternalAttribute : ReferenceConstraint
    {
        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// from another namespace than the namespace of the declaration.
        /// </summary>
        public ComponentInternalAttribute()
        {
            Severity = SeverityType.Warning;
        }

        /// <summary>
        /// Gets or sets the severity of messages emitted by this constraint.
        /// </summary>
        /// <remarks>
        /// <para>The default value is <see cref="SeverityType.Warning"/>.</para>
        /// </remarks>
        public SeverityType Severity { get; set; }

        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// outside of given types or namespaces, given as <see cref="Type"/>.
        /// </summary>
        /// <param name="friendTypes">List of types from which the target declaration can be used. If the name of a
        /// type is <c>NamespaceType</c>, the whole namespace of this type is allowed.</param>
        public ComponentInternalAttribute( params Type[] friendTypes )
            : this()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a <see cref="ComponentInternalAttribute"/> restricting the target declaration from being used
        /// outside of given types or namespaces, given by strings.
        /// </summary>
        /// <param name="friendNamespaces">List of types or namespaces from which the target declaration
        /// can be used.</param>
        public ComponentInternalAttribute( params string[] friendNamespaces )
            : this()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected override void ValidateReference( ICodeReference codeReference )
        {
            throw new NotImplementedException();
        }
    }
}
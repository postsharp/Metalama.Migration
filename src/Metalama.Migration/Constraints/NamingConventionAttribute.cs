using System;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Custom attribute that, when applied to a target class or an interface, validates that classes and interfaces derived from this target class or interface
    /// respect a giving naming convention, i.e. that their names matches a given pattern.
    /// </summary>
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Interface, Inheritance = MulticastInheritance.Strict )]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly )]
    public sealed class NamingConventionAttribute : ScalarConstraint
    {
        /// <summary>
        /// Initializes a new <see cref="NamingConventionAttribute"/>.
        /// </summary>
        /// <param name="pattern">A wildcard pattern containing a <code>*</code>, or, if the parameter starts with the <code>regex:</code> prefix, a regular expression.</param>
        public NamingConventionAttribute( string pattern )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the severity of messages reporting violations of the current naming convention.
        /// </summary>
        public SeverityType Severity { get; set; } = SeverityType.Warning;

        /// <inheritdoc />
        public override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void ValidateCode( object target )
        {
            throw new NotImplementedException();
        }
    }
}
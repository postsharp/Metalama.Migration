using System.Reflection;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Implementation of <see cref="IReferentialConstraint"/> based on <see cref="MulticastAttribute"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class ReferentialConstraint : Constraint, IReferentialConstraint
    {
        /// <inheritdoc />
        public virtual void ValidateCode( object target, Assembly assembly ) { }
    }
}
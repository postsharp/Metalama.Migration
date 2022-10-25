using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix
namespace PostSharp.Constraints
{
    /// <summary>
    /// Implementation of <see cref="IScalarConstraint"/> based on <see cref="MulticastAttribute"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class ScalarConstraint : Constraint, IScalarConstraint
    {
        /// <inheritdoc />
        public virtual void ValidateCode( object target ) { }
    }
}
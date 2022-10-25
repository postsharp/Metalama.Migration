#pragma warning disable CA1710 // Identifiers should have correct suffix
namespace PostSharp.Constraints
{
    public class ScalarConstraint : Constraint, IScalarConstraint
    {
        public virtual void ValidateCode( object target ) { }
    }
}
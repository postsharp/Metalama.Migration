using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    public abstract class Constraint : MulticastAttribute, IConstraint
    {
        public virtual bool ValidateConstraint( object target )
        {
            return true;
        }
    }
}
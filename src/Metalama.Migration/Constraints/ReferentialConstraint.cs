using System.Reflection;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    public abstract class ReferentialConstraint : Constraint, IReferentialConstraint
    {
        public virtual void ValidateCode( object target, Assembly assembly ) { }
    }
}
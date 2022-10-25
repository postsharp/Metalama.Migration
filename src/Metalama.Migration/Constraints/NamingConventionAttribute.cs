using System;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Interface, Inheritance = MulticastInheritance.Strict )]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly )]
    public sealed class NamingConventionAttribute : ScalarConstraint
    {
        public NamingConventionAttribute( string pattern )
        {
            throw new NotImplementedException();
        }

        public SeverityType Severity { get; set; } = SeverityType.Warning;

        public override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        public override void ValidateCode( object target )
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp.Reflection.MethodBody;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    [AttributeUsage( AttributeTargets.Parameter )]
    [MulticastAttributeUsage( MulticastTargets.Parameter, Inheritance = MulticastInheritance.Strict )]
    public abstract class ParameterValueConstraint : ReferentialConstraint
    {
        public sealed override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        protected virtual bool ValidateTargetParameter( ParameterInfo parameter )
        {
            throw new NotImplementedException();
        }

        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }

        protected abstract void ValidateParameterValue( ParameterInfo parameter, IExpression expression );
    }
}
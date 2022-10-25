using System;
using System.Reflection;
using PostSharp.Extensibility;
using PostSharp.Reflection.MethodBody;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Base class to create architecture constraints that validate the value passed to a method parameter.
    /// </summary>
    [AttributeUsage( AttributeTargets.Parameter )]
    [MulticastAttributeUsage( MulticastTargets.Parameter, Inheritance = MulticastInheritance.Strict )]
    public abstract class ParameterValueConstraint : ReferentialConstraint
    {
        /// <exclude/>
        public sealed override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates the parameter to which the current constraint has been applied. A typical use of this method is to validate the parameter type.
        /// Overriding implementations should call the base implementation.
        /// </summary>
        /// <param name="parameter">The parameter to which the custom attribute has been applied.</param>
        /// <returns><c>true</c> if the current constraint can legally be applied to <paramref name="parameter"/>, <c>false</c> otherwise. No error message is emitted if
        /// the method returns <c>false</c>. The method should emit its own error message.</returns>
        protected virtual bool ValidateTargetParameter( ParameterInfo parameter )
        {
            throw new NotImplementedException();
        }

        /// <exclude/>
        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validates the value passed to the parameter.
        /// </summary>
        /// <param name="parameter">The parameter to which the current constraint has been applied.</param>
        /// <param name="expression">The expression passed to the parameter.</param>
        protected abstract void ValidateParameterValue( ParameterInfo parameter, IExpression expression );
    }
}
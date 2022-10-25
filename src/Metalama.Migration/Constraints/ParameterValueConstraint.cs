// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using PostSharp.Constraints;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using PostSharp.Reflection.MethodBody;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Base class to create architecture constraints that validate the value passed to a method parameter.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    [MulticastAttributeUsage(MulticastTargets.Parameter, Inheritance = MulticastInheritance.Strict)]
    public abstract class ParameterValueConstraint : ReferentialConstraint
    {
        /// <exclude/>
        public sealed override bool ValidateConstraint( object target )
        {
            return this.ValidateTargetParameter( (ParameterInfo) target );
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
            if ( !(parameter.Member is MethodBase) )
            {
                ArchitectureMessageSource.Instance.Write(MessageLocation.Of(parameter), SeverityType.Error, "AR0111", this.GetType().Name, parameter);
                return false;
            }
            return true;
        }

        /// <exclude/>
        public sealed override void ValidateCode( object target, Assembly assembly )
        {
            ParameterInfo targetParameter = (ParameterInfo) target;
            IMethodBodyService methodBodyService = PostSharpEnvironment.CurrentProject.GetService<IMethodBodyService>();

            foreach ( MethodUsageCodeReference usage in ReflectionSearch.GetMethodsUsingDeclaration( targetParameter.Member ) )
            {
                IMethodBody methodBody = methodBodyService.GetMethodBody( usage.UsingMethod, MethodBodyAbstractionLevel.ExpressionTree );
                Visitor visitor = new Visitor( targetParameter, this );
                visitor.VisitMethodBody( methodBody );
            }

        }

        /// <summary>
        /// Validates the value passed to the parameter.
        /// </summary>
        /// <param name="parameter">The parameter to which the current constraint has been applied.</param>
        /// <param name="expression">The expression passed to the parameter.</param>
        protected abstract void ValidateParameterValue( ParameterInfo parameter, IExpression expression );
        

        class Visitor : MethodBodyVisitor
        {
            private readonly ParameterInfo targetParameter;
            private readonly ParameterValueConstraint parent;

            public Visitor( ParameterInfo targetParameter, ParameterValueConstraint parent )
            {
                this.targetParameter = targetParameter;
                this.parent = parent;
            }

            public override object VisitMethodCallExpression( IMethodCallExpression expression )
             {
                 if ( expression.Method == this.targetParameter.Member )
                 {
                     this.parent.ValidateParameterValue( this.targetParameter, expression.Arguments[this.targetParameter.Position] );
                 }

                return base.VisitMethodCallExpression( expression );
            }
        }
    }
}

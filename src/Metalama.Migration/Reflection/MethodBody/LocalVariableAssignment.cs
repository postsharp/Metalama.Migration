// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Reflection.MethodBody
{
#pragma warning disable CA1815 // Override equals and operator equals on value types

    /// <summary>
    /// Represents the assignment of a local variable to an expression.
    /// </summary>
    public struct LocalVariableAssignment
    {
        internal LocalVariableAssignment( ILocalVariable localVariable, IExpression expression ) : this()
        {
            this.LocalVariable = localVariable;
            this.Expression = expression;
        }

        /// <summary>
        /// Gets the local variable being assigned.
        /// </summary>
        public ILocalVariable LocalVariable { get; private set; }

        /// <summary>
        /// Gets the expression to which the local variable is being assigned.
        /// </summary>
        public IExpression Expression { get; private set; }
    }
}

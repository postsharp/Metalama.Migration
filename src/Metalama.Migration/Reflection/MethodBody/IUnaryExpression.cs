// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents an expression with a single operand.
    /// </summary>
    public interface IUnaryExpression : IExpression
    {
        /// <summary>
        /// Operand of the unary expression.
        /// </summary>
        IExpression Value { get; }
    }
}

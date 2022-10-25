// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Conditional expression, corresponding to the <c>if</c> keyword in C#.
    /// </summary>
    public interface IConditionalExpression : IExpression
    {
        /// <summary>
        /// Gets the condition expression (the return type does not need to be <c>bool</c>. Zero and <c>null</c> values are considered <c>false</c>).
        /// </summary>
        IExpression Condition { get; }

        /// <summary>
        /// Gets the expression executed when <see cref="Condition"/> evaluates to <c>true</c> or a non-null and non-zero vale.
        /// </summary>
        IExpression IfTrue { get; }

        /// <summary>
        /// Gets the expression executed when <see cref="Condition"/> evaluates to <c>false</c>, zero, or <c>null</c>.
        /// </summary>
        IExpression IfFalse { get; }
    }
}

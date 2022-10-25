// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that has two operands, <see cref="Left"/> and <see cref="Right"/>.
    /// </summary>
    [Experimental]
    public interface IBinaryExpression : IExpression
    {
        /// <summary>
        /// Gets the left operand.
        /// </summary>
        IExpression Left { get; }

        /// <summary>
        /// Gets the right operand.
        /// </summary>
        IExpression Right { get; }
    }
}


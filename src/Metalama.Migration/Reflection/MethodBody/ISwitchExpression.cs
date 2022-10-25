// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represent a switch (conditional statement with multiple branches).
    /// </summary>
    /// <remarks>
    ///     <para>This interface represents the MSIL <c>switch</c> statement, not the C#
    ///           statement. The main difference is that switch cases have no value: the value of a switch case is equal to
    ///           its position in the list of <see cref="Targets"/>.
    /// </para>
    /// </remarks>
    public interface ISwitchExpression : IExpression
    {
        /// <summary>
        /// Gets the condition expression.
        /// </summary>
        IExpression Condition { get; }

        /// <summary>
        /// Gets the list of target blocks.
        /// </summary>
        IList<IExpression> Targets { get; }
    }
}


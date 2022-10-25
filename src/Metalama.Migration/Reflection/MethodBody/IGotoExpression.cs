// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Unconditional branching instruction.
    /// </summary>
    public interface IGotoExpression : IExpression
    {
        /// <summary>
        /// Instruction block that must receive control.
        /// </summary>
        IBlockExpression Target { get; }
    }
}


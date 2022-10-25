// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents an expression or an instruction.
    /// </summary>
    public interface IExpression : IMethodBodyElement
    {
        /// <summary>
        /// Gets the type of the return value of the current expression,
        /// or <see cref="System.Void"/> if the expression does not return anything (i.e. for pure instructions, for instance a <c>goto</c>
        /// or <c>throw</c> instruction).
        /// </summary>
        Type ReturnType { get; }

        ///// <summary>
        ///// Gets a source location of this expression, if available.
        ///// </summary>
        //SyntaxLocation Location { get; }
    }
}

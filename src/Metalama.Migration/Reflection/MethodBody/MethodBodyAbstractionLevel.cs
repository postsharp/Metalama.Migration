// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{

    /// <summary>
    /// Enumerates the level of abstraction and the level of details produced by the AST decompiler.
    /// </summary>
    /// <see cref="IMethodBodyService"/>
    public enum MethodBodyAbstractionLevel
    {
        /// <summary>
        /// Returns only the block structure (exception handlers).
        /// </summary>
        Structure,

        /// <summary>
        /// Returns the expression tree.
        /// </summary>
        ExpressionTree
    }
}


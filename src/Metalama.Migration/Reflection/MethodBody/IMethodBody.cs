// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents the body of a method.
    /// </summary>
    public interface IMethodBody : IMethodBodyElement
    {
        /// <summary>
        /// Gets the method whose body is represented by the current object.
        /// </summary>
        MethodBase Method { get; }

        /// <summary>
        /// Gets the root instruction block of the method.
        /// </summary>
        IBlockExpression RootBlock { get; }
    }
}


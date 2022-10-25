// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a C-like pointer to a method.
    /// </summary>
    public interface IMethodPointerExpression : IExpression
    {
        /// <summary>
        /// Gets the instance on which the method is defined, or <c>null</c> if the method is static.
        /// </summary>
        IExpression Instance { get; }

        /// <summary>
        /// Gets the method.
        /// </summary>
        MethodBase Method { get; }
    }
}


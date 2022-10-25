// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a method parameter.
    /// </summary>
    public interface IParameterExpression : IExpression
    {
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        ParameterInfo Parameter { get; }
    }
}


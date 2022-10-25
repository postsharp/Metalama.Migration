// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression representing a build-time constant.
    /// </summary>
    public interface IConstantExpression : IExpression
    {
        /// <summary>
        /// Gets the constant value.
        /// </summary>
        object Value { get; }
    }
}


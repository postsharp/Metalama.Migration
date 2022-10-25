// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that returns a new array.
    /// </summary>
    public interface INewArrayExpression : IExpression
    {
        /// <summary>
        /// Gets the number of elements in the array.
        /// </summary>
        IExpression Length { get; }

        /// <summary>
        /// Gets the type of elements of the array.
        /// </summary>
        Type ElementType { get; }
    }
}

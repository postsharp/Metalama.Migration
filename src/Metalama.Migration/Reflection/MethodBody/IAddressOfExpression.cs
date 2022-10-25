// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that takes the address of the operand. Equivalent to the C# operator <c>&amp;</c>.
    /// </summary>
    public interface IAddressOfExpression : IUnaryExpression
    {
        /// <summary>
        /// Determines whether the returned pointer is a read-only pointer.
        /// </summary>
        bool IsReadOnly { get; }
    }
}


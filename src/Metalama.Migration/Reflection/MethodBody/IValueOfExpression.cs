// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that returns the value stored at an address. Equivalent to the C# keyword <c>*</c>.
    /// </summary>
    public interface IValueOfExpression : IUnaryExpression
    {
        /// <summary>
        /// Determines whether if the location at the address is volatile, i.e. if it can be changed
        /// by a different thread than the current one.
        /// </summary>
        bool IsVolatile { get; }


        /// <summary>
        /// Gets the alignment of the value at the address.
        /// </summary>
        AddressAlignment Alignment { get; }
    }
}

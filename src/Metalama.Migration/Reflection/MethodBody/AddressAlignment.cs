// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Enumeration of address alignments for access to unmanaged memory represented
    /// by <see cref="ICopyBufferExpression"/>, <see cref="IFieldExpression"/> or <see cref="IValueOfExpression"/>.
    /// </summary>
    public enum AddressAlignment
    {
        /// <summary>
        /// Default alignment (machine word).
        /// </summary>
        Default,

        /// <summary>
        /// 1-byte alignment.
        /// </summary>
        Unaligned1,

        /// <summary>
        /// 2-byte alignment.
        /// </summary>
        Unaligned2,

        /// <summary>
        /// 4-byte alignment.
        /// </summary>
        Unaligned4
    }
}


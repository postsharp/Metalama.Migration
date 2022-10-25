// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if !LEGACY_REFLECTION_API
using System.Reflection.Emit;

#endif

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression equivalent to the <c>initblk</c> instruction.
    /// </summary>
    /// <remarks>
    /// <para>This expression type has no equivalent in C#.</para>
    /// </remarks>
    public interface IInitBufferExpression : IExpression
    {
        /// <summary>
        /// Gets the address of the buffer to be initialized.
        /// </summary>
        IExpression Buffer { get; }

        /// <summary>
        /// Gets the number of bytes to be initialized.
        /// </summary>
        IExpression Length { get; }

        /// <summary>
        /// Determines whether the buffers can be modified from a different thread.
        /// </summary>
        bool IsVolatile { get; }

        /// <summary>
        /// Gets the alignment of the buffers.
        /// </summary>
        AddressAlignment Alignment { get; }
    }
}

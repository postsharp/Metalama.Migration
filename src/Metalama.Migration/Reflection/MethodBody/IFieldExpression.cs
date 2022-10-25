// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a field.
    /// </summary>
    public interface IFieldExpression : IExpression
    {
        /// <summary>
        /// Gets the object containing the field, or <c>null</c> if the field is static.
        /// </summary>
        IExpression Instance { get; }

        /// <summary>
        /// Gets the field.
        /// </summary>
        FieldInfo Field { get; }

        /// <summary>
        /// Determine whether the field is can be written by a different thread than the current one.
        /// </summary>
        bool IsVolatile { get; }

        /// <summary>
        /// Gets the field alignment.
        /// </summary>
        AddressAlignment Alignment { get; }
    }
}

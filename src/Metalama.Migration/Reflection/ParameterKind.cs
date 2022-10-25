// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;

#pragma warning disable CA1028 // Enum Storage should be Int32

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="RefKind"/>.
    /// </summary>
    public enum ParameterKind : byte
    {
        InValue,

        ByRefIn,

        ByRefOut,

        ByRefInOut,

        ReturnValue,

        ReturnRef
    }
}
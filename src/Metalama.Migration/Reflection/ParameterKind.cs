// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#pragma warning disable CA1028 // Enum Storage should be Int32

namespace PostSharp.Reflection
{
    /// <summary>
    /// Enumerates all possible kinds of method parameters. The parameter kind indicates whether the parameter is by ref or by value and its direction.
    /// </summary>
    public enum ParameterKind : byte
    {
        /// <summary>
        /// Normal (input) parameter.
        /// </summary>
        InValue,
        
        /// <summary>
        /// The read-only parameter passed by reference (<c>in</c> parameters since C# 7.2).
        /// </summary>
        ByRefIn,
        
        /// <summary>
        /// <c>out</c> parameter.
        /// </summary>
        ByRefOut,
        
        /// <summary>
        /// <c>ref</c> parameter.
        /// </summary>
        ByRefInOut,
        
        /// <summary>
        /// The return value parameter.
        /// </summary>
        ReturnValue,
        
        /// <summary>
        /// The reference return value parameter (<c>ref</c> returns since C# 7.0).
        /// </summary>
        ReturnRef
    }
}
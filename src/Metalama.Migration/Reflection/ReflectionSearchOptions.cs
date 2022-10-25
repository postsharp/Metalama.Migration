// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// </summary>
    /// <remarks>
    /// </remarks>
    [Flags]
    public enum ReflectionSearchOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Include relationships referencing a derived type (instead of exactly that type).
        /// </summary>
        IncludeDerivedTypes = 1,

        /// <summary>
        /// Include relationships referencing a type signature including the given type (instead of only the given type).
        /// </summary>
        IncludeTypeElement = 2,

    }
}

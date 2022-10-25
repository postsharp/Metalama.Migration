// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Enumerates the kinds of code elements that can be encapsulated by a <see cref = "LocationInfo" />.
    /// </summary>
    public enum LocationKind
    {
        /// <summary>
        ///   <see cref = "FieldInfo" />.
        /// </summary>
        Field,

        /// <summary>
        ///   <see cref = "PropertyInfo" />.
        /// </summary>
        Property,

        /// <summary>
        ///   A <see cref = "ParameterInfo" /> representing a parameter (not a <see cref = "ReturnValue" />).
        /// </summary>
        Parameter,

        /// <summary>
        ///   A <see cref = "ParameterInfo" /> representing a return value.
        /// </summary>
        ReturnValue
    }
}

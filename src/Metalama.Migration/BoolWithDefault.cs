// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp
{
    /// <summary>
    ///   Boolean with a "default" value. For use in design-time configurable boolean properties.
    /// </summary>
    internal enum BoolWithDefault : byte
    {
        /// <summary>
        ///   Indicates that the value has not been set.
        /// </summary>
        Default,

        /// <summary>
        ///   Indicates that the value has been set to <c>true</c>.
        /// </summary>
        True,

        /// <summary>
        ///   Indicates that the value has been set to <c>false</c>.
        /// </summary>
        False
    }
}
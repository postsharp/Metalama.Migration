// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Enumerates the possible contexts in which the location validation advices can be invoked.
    /// </summary>
    /// <remarks>
    ///   This enumeration can be passed as an argument to the method marked with the <see cref="LocationValidationAdvice"/> attribute.
    /// </remarks>
    public enum LocationValidationContext
    {
        /// <summary>
        /// None.
        /// </summary>
        None = 0,

        /// <summary>
        /// The value is being validated on method entry.
        /// </summary>
        Precondition = 1,

        /// <summary>
        /// The value is being validated just before the method successfully returns.
        /// </summary>
        SuccessPostcondition = 2
    }
}
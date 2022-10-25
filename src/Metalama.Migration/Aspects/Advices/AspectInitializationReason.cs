// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Text;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Enumerates the reasons why the target method of the <see cref="InitializeAspectInstanceAdvice"/> has been invoked.
    /// </summary>
    public enum AspectInitializationReason
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Manual call of the <c>InitializeAspects</c> method.
        /// </summary>
        Manual,

        /// <summary>
        /// Call from the instance constructor.
        /// </summary>
        Constructor,

        /// <summary>
        /// Call from <c>MemberwiseClone</c>.
        /// </summary>
        Clone,

        /// <summary>
        /// Call during deserialization.
        /// </summary>
        Deserialize
    }

}

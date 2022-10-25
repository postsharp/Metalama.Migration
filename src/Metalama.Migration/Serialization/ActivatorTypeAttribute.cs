// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Custom attribute that, when applied to an assembly, points to a type in the assembly implementing <see cref="IActivator"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public sealed class ActivatorTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="ActivatorTypeAttribute"/>.
        /// </summary>
        /// <param name="activatorType">A type derived from <see cref="IActivator"/> in the current assembly. This type must be public and have
        /// a default constructor.</param>
        public ActivatorTypeAttribute( Type activatorType )
        {
            this.ActivatorType = activatorType;
        }

        /// <summary>
        /// Gets the activator type.
        /// </summary>
        public Type ActivatorType { get; private set; }
    }
}

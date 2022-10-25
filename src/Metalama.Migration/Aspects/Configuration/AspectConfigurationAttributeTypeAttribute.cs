// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// Custom attribute that, when applied to an aspect, specifies which custom attribute type
    /// (derived from <see cref="AspectConfigurationAttribute"/>) can provide declarative configuration for the aspect.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class AspectConfigurationAttributeTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="AspectConfigurationAttribute"/>.
        /// </summary>
        /// <param name="type">Custom attribute type
        /// (derived from <see cref="AspectConfigurationAttribute"/>).</param>
        public AspectConfigurationAttributeTypeAttribute( Type type)
        {
            this.AttributeType = type;
        }

        /// <summary>
        /// Gets the type of the custom attribute 
        /// (derived from <see cref="AspectConfigurationAttribute"/>) that can provide declarative configuration for the aspect.
        /// </summary>
        public Type AttributeType { get; }
    }
}
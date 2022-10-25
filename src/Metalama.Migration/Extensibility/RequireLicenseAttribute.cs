// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <exclude/>
    /// <summary>
    /// Custom attribute that, when applied to an aspect, causes PostSharp to require some license in order to weave the aspect.
    /// </summary>
    /// <remarks>
    /// <para>When several instances of this custom attributes are available, the license check will be satisfied with any of them.</para>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    [Internal]
    [Obsolete( "Licensing is now based on hard-coded assembly name." )]
    public sealed class RequireLicenseAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="RequireLicenseAttribute"/>.
        /// </summary>
        /// <param name="product">Identifier of the licensed product.</param>
        
        public RequireLicenseAttribute( int product )
        {
            this.Product = product;
        }

        /// <summary>
        /// Gets the identifier of the required licensed product.
        /// </summary>
        public int Product { get; private set; }
        

        /// <summary>
        /// Gets or sets the bitmask of required licensed features.
        /// </summary>
        public long Features { get; set; }

        /// <summary>
        /// Gets or sets the human-readable description of the license requirement.
        /// </summary>
        public string Description { get; set; }
    }
}

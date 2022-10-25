// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.ComponentModel;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="DescriptionAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class AspectDescriptionAttribute : Attribute
    {
        public AspectDescriptionAttribute( string description )
        {
            this.Description = description;
        }

        public string Description { get; }
    }
}
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

#pragma warning disable IDE0060 // Remove unused parameter (metadata is used)

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Assembly )]
    public sealed class AssemblyIdAttribute : Attribute
    {
        public AssemblyIdAttribute( int id )
        {
            this.AssemblyId = id;
        }

        public int AssemblyId { get; }
    }
}
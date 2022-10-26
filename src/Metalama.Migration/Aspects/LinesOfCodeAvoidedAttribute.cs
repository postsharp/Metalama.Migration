// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// This feature is not implemented in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class LinesOfCodeAvoidedAttribute : Attribute
    {
        public LinesOfCodeAvoidedAttribute( int lines )
        {
            throw new NotImplementedException();
        }

        public int Count { get; }
    }
}
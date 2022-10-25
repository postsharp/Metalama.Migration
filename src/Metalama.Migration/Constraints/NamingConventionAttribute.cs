// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using System;

namespace PostSharp.Constraints
{
    /// <summary>
    /// Not implemented yet in Metalama, but it will be.
    /// </summary>
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Interface, Inheritance = MulticastInheritance.Strict )]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly )]
    public sealed class NamingConventionAttribute : ScalarConstraint
    {
        public NamingConventionAttribute( string pattern )
        {
            throw new NotImplementedException();
        }

        public SeverityType Severity { get; set; } = SeverityType.Warning;

        public override bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }

        public override void ValidateCode( object target )
        {
            throw new NotImplementedException();
        }
    }
}
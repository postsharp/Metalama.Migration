// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

#pragma warning disable CA1710 // Identifiers should have correct suffix
namespace PostSharp.Constraints
{
    public class ScalarConstraint : Constraint, IScalarConstraint
    {
        public virtual void ValidateCode( object target ) { }
    }
}

// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Constraints
{
    public class ScalarConstraint : Constraint, IScalarConstraint
    {
        public virtual void ValidateCode( object target ) { }
    }
}
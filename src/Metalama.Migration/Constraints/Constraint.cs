// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Extensibility;
using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    public abstract class Constraint : MulticastAttribute, IConstraint
    {
        public virtual bool ValidateConstraint( object target )
        {
            throw new NotImplementedException();
        }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Implementation of <see cref="IReferentialConstraint"/> based on <see cref="MulticastAttribute"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class ReferentialConstraint : Constraint, IReferentialConstraint
    {
        /// <inheritdoc />
        public virtual void ValidateCode( object target, Assembly assembly )
        {
        }

    }

}
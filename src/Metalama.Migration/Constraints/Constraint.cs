// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Constraints
{
    /// <summary>
    /// Root class for all constraints based on <see cref="MulticastAttribute"/>.
    /// A constraint is a piece validation logic executed at build time. Constraints
    /// are applied to elements of code ((<see cref="Assembly"/>, <see cref="Type"/>,
    /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>,
    /// <see cref="EventInfo"/>, <see cref="FieldInfo"/>, <see cref="ParameterInfo"/>)
    /// typically using multicast custom attributes, and verified
    /// at build time for every assembly using this element of code.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class Constraint : MulticastAttribute, IConstraint
    {
        /// <inheritdoc />
        public virtual bool ValidateConstraint( object target )
        {
            return true;
        }
    }

}
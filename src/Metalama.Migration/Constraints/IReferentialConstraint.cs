// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// A referential constraint is a piece validation logic executed at build time. Referential constraints
    /// are applied to elements of code ((<see cref="Assembly"/>, <see cref="Type"/>,
    /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>,
    /// <see cref="EventInfo"/>, <see cref="FieldInfo"/>, <see cref="ParameterInfo"/>),
    /// typically using custom attributes or <see cref="MulticastAttribute"/>, and verified
    /// at build time for every assembly using this element of code. This is a difference to scalar constraints,
    /// which are only verified for the assembly where that element of code is defined.
    /// </summary>
    /// <remarks>
    /// </remarks>
    
    public interface IReferentialConstraint : IConstraint
    {
        /// <summary>
        /// Validates the constraint.
        /// </summary>
        /// <param name="target">Declaration (<see cref="Assembly"/>, <see cref="Type"/>,
        /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>,
        /// <see cref="EventInfo"/>, <see cref="FieldInfo"/>, <see cref="ParameterInfo"/>) to which
        /// the constraint has been applied.</param>
        /// <param name="assembly">The assembly being currently processed.</param>
        void ValidateCode( object target, Assembly assembly );
    }


}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace PostSharp.Constraints
{
    /// <summary>
    /// A constraint that validates a specific element of code. Use an <see cref="IReferentialConstraint"/>
    /// to validate relationships between elements of code.
    /// </summary>
    /// <remarks>
    /// </remarks>
    /// <seealso cref="ScalarConstraint"/>
    public interface IScalarConstraint : IConstraint
    {
        /// <summary>
        /// Validates the element of code to which the constraint is applied.
        /// </summary>
        /// <param name="target">Element of code to which the constraint is applied (<see cref="Assembly"/>, <see cref="Type"/>,
        /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>,
        /// <see cref="EventInfo"/>, <see cref="FieldInfo"/>, <see cref="ParameterInfo"/>).</param>
        void ValidateCode( object target );
    }

}
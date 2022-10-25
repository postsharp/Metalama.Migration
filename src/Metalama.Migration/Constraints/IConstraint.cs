using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Constraints
{
    /// <summary>
    /// A constraint is a piece of validation logic executed at build time. Constraints
    /// are applied to elements of code (<see cref="Assembly"/>, <see cref="Type"/>,
    /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>,
    /// <see cref="EventInfo"/>, <see cref="FieldInfo"/>, <see cref="ParameterInfo"/>),
    /// typically (but not necessarily) using custom attributes or <see cref="MulticastAttribute"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [RequirePostSharp( null, "ArchitectureConstraint" )]
    public interface IConstraint
    {
        /// <summary>
        /// Validates the fact that the constraint has been applied on a valid element of code. When this
        /// method returns <c>false</c>, the constraint is silently ignored.
        /// </summary>
        /// <param name="target"></param>
        /// <returns><c>true</c> if the constraint has been applied on a valid element of code, otherwise <c>false</c>.</returns>
        bool ValidateConstraint( object target );
    }
}
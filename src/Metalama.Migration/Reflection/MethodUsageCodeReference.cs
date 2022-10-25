using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Represents a relationship between a declaration (<see cref="Type"/>,
    /// <see cref="FieldInfo"/>, <see cref="MethodInfo"/> or <see cref="ConstructorInfo"/>)
    /// and a method whose instructions (method body) use the declaration.
    /// </summary>
    public sealed class MethodUsageCodeReference : ICodeReference
    {
        /// <summary>
        /// Gets the method (<see cref="MethodInfo"/> or <see cref="ConstructorInfo"/>)
        /// whose body uses the declaration.
        /// </summary>
        public MethodBase UsingMethod { get; }

        /// <summary>
        /// Gets the declaration (<see cref="Type"/>, <see cref="MethodInfo"/>
        /// or <see cref="ConstructorInfo"/>) used by the method.
        /// </summary>
        public MemberInfo UsedDeclaration { get; }

        /// <summary>
        /// Gets the <see cref="Type"/> used by the method. If the current
        /// object represents a reference to a <see cref="MethodInfo"/>
        /// or <see cref="ConstructorInfo"/>, this property returns the declaring
        /// type of the method or constructor.
        /// </summary>
        public Type UsedType { get; }

        /// <summary>
        /// Gets the instructions that reference <see cref="UsedDeclaration"/>.
        /// </summary>
        public MethodUsageInstructions Instructions { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration { get; }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
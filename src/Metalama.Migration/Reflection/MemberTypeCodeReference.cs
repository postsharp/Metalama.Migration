using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Represents a relationship between a type and a member of this type.
    /// A member can be a <see cref="FieldInfo"/>, <see cref="PropertyInfo"/>, or
    /// <see cref="ParameterInfo"/>.
    /// </summary>
    public sealed class MemberTypeCodeReference : ICodeReference
    {
        /// <summary>
        /// Gets the member type.
        /// </summary>
        public Type Type { get; }

        /// <summary>
        /// Gets the member (<see cref="FieldInfo"/>, <see cref="PropertyInfo"/>, or
        /// <see cref="ParameterInfo"/>).
        /// </summary>
        public object Member { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration { get; }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Represents a inheritance relationship between two types.
    /// </summary>
    public sealed class TypeInheritanceCodeReference : ICodeReference
    {
        /// <summary>
        /// Gets the base type. If the base type is a generic type, this property contains
        /// a generic type instance.
        /// </summary>
        public Type BaseType { get; }

        /// <summary>
        /// Gets the derived type.
        /// </summary>
        public Type DerivedType { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration { get; }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration { get; }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
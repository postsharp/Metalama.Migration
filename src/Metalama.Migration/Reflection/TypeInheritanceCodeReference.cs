using System;
using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="ReferenceValidationContext"/>.
    /// </summary>
    public sealed class TypeInheritanceCodeReference : ICodeReference
    {
        public Type BaseType { get; }

        public Type DerivedType { get; }

        object ICodeReference.ReferencingDeclaration { get; }

        object ICodeReference.ReferencedDeclaration { get; }

        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
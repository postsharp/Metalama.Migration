using System;

namespace PostSharp.Reflection
{
    public sealed class TypeInheritanceCodeReference : ICodeReference
    {
        public Type BaseType { get; }

        public Type DerivedType { get; }

        object ICodeReference.ReferencingDeclaration { get; }

        object ICodeReference.ReferencedDeclaration { get; }

        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
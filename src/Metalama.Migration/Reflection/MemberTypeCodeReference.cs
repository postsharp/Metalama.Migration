using System;

namespace PostSharp.Reflection
{
    public sealed class MemberTypeCodeReference : ICodeReference
    {
        public Type Type { get; }

        public object Member { get; }

        object ICodeReference.ReferencingDeclaration { get; }

        object ICodeReference.ReferencedDeclaration { get; }

        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
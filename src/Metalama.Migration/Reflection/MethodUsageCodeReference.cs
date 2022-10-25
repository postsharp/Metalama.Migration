using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    public sealed class MethodUsageCodeReference : ICodeReference
    {
        public MethodBase UsingMethod { get; }

        public MemberInfo UsedDeclaration { get; }

        public Type UsedType { get; }

        public MethodUsageInstructions Instructions { get; }

        object ICodeReference.ReferencingDeclaration { get; }

        object ICodeReference.ReferencedDeclaration { get; }

        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
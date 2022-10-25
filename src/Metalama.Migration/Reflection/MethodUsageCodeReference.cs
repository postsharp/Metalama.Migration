using System;
using System.Reflection;
using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="ReferenceValidationContext"/>.
    /// </summary>
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
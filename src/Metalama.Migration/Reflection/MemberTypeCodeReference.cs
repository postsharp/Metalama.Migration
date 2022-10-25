using System;
using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="ReferenceValidationContext"/>.
    /// </summary>
    public sealed class MemberTypeCodeReference : ICodeReference
    {
        public Type Type { get; }

        public object Member { get; }

        object ICodeReference.ReferencingDeclaration { get; }

        object ICodeReference.ReferencedDeclaration { get; }

        CodeReferenceKind ICodeReference.ReferenceKind { get; }
    }
}
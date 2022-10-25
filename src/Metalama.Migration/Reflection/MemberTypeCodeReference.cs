// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Validation;
using System;

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
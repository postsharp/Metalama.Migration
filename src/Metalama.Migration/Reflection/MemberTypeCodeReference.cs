// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

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
        internal MemberTypeCodeReference( Type type, object member )
        {
            this.Type = type;
            this.Member = member;
        }

        /// <summary>
        /// Gets the member type.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the member (<see cref="FieldInfo"/>, <see cref="PropertyInfo"/>, or
        /// <see cref="ParameterInfo"/>).
        /// </summary>
        public object Member { get; private set; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration
        {
            get { return this.Member; }
        }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration
        {
            get { return this.Type; }
        }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind
        {
            get { return CodeReferenceKind.MemberType; }
        }
    }
}
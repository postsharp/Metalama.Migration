// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Represents a inheritance relationship between two types.
    /// </summary>
    public sealed class TypeInheritanceCodeReference : ICodeReference
    {
        internal TypeInheritanceCodeReference( Type baseType, Type derivedType )
        {
            this.BaseType = baseType;
            this.DerivedType = derivedType;
        }

        /// <summary>
        /// Gets the base type. If the base type is a generic type, this property contains
        /// a generic type instance.
        /// </summary>
        public Type BaseType { get; private set; }

        /// <summary>
        /// Gets the derived type.
        /// </summary>
        public Type DerivedType { get; private set; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration
        {
            get { return this.DerivedType; }
        }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration
        {
            get { return this.BaseType; }
        }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind
        {
            get { return CodeReferenceKind.TypeInheritance; }
        }
    }
}
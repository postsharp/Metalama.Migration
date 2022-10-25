// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Represents a reference between two declarations.
    /// </summary>
    public interface ICodeReference
    {
        /// <summary>
        ///   Gets the declaration referencing the other.
        /// </summary>
        object ReferencingDeclaration { get; }

        /// <summary>
        ///   Gets the declaration referenced by the other.
        /// </summary>
        object ReferencedDeclaration { get; }

        /// <summary>
        ///   Gets the kind of code reference.
        /// </summary>
        CodeReferenceKind ReferenceKind { get; }
    }
}
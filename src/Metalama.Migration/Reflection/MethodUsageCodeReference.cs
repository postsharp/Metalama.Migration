// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Represents a relationship between a declaration (<see cref="Type"/>,
    /// <see cref="FieldInfo"/>, <see cref="MethodInfo"/> or <see cref="ConstructorInfo"/>)
    /// and a method whose instructions (method body) use the declaration.
    /// </summary>
    public sealed class MethodUsageCodeReference : ICodeReference
    {
        internal MethodUsageCodeReference( MethodBase usingMethod, MemberInfo usedMember, MethodUsageInstructions instructions )
        {
#if DEBUG
            if (usingMethod == null) throw new ArgumentNullException( nameof(usingMethod));
            if (usedMember == null) throw new ArgumentNullException( nameof(usedMember));
#endif
            this.UsingMethod = usingMethod;
            this.UsedDeclaration = usedMember;
            this.Instructions = instructions;
        }

        /// <summary>
        /// Gets the method (<see cref="MethodInfo"/> or <see cref="ConstructorInfo"/>)
        /// whose body uses the declaration.
        /// </summary>
        public MethodBase UsingMethod { get; private set; }

        /// <summary>
        /// Gets the declaration (<see cref="Type"/>, <see cref="MethodInfo"/>
        /// or <see cref="ConstructorInfo"/>) used by the method.
        /// </summary>
        public MemberInfo UsedDeclaration { get; private set; }

        /// <summary>
        /// Gets the <see cref="Type"/> used by the method. If the current
        /// object represents a reference to a <see cref="MethodInfo"/>
        /// or <see cref="ConstructorInfo"/>, this property returns the declaring
        /// type of the method or constructor.
        /// </summary>
        public Type UsedType
        {
            get { return this.UsedDeclaration.AsType() ?? this.UsedDeclaration.DeclaringType; }
        }

        /// <summary>
        /// Gets the instructions that reference <see cref="UsedDeclaration"/>.
        /// </summary>
        public MethodUsageInstructions Instructions { get; private set; }

        /// <inheritdoc />
        object ICodeReference.ReferencingDeclaration
        {
            get { return this.UsingMethod; }
        }

        /// <inheritdoc />
        object ICodeReference.ReferencedDeclaration
        {
            get { return this.UsedDeclaration; }
        }

        /// <inheritdoc />
        CodeReferenceKind ICodeReference.ReferenceKind
        {
            get { return CodeReferenceKind.MethodUsage; }
        }
    }
}
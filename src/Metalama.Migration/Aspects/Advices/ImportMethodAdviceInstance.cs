// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Represents an advises that import a method of the target class into the aspect class.
    /// </summary>
    public sealed class ImportMethodAdviceInstance : ImportMemberAdviceInstance
    {
        private readonly string[] memberNames;

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportMethodAdviceInstance"/>.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class into that will be assigned to a delegate of the imported method at runtime. The field type should be a delegate of the same signature than the method to import.</param>
        /// <param name="methodName">Name of the method to import.</param>
        /// <param name="isRequired"><c>true</c> if the build should fail if there no matching method in the target class, <c>false</c> to set <paramref name="aspectField"/> to <c>null</c> in this case.</param>
        /// <param name="order">Determines whether the <paramref name="aspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.
        /// </param>
        public ImportMethodAdviceInstance( FieldInfo aspectField, string methodName, bool isRequired = false,
                                           ImportMemberOrder order = ImportMemberOrder.Default ) : base( aspectField, order, isRequired )
        {
            if ( string.IsNullOrEmpty( methodName ) )
                throw new ArgumentNullException( nameof(methodName));

            this.memberNames = new[] { methodName };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImportMethodAdviceInstance"/>.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class into that will be assigned to a delegate of the imported method at runtime. The field type should be a delegate of the same signature than the method to import.</param>
        /// <param name="methodNames">Fallback list of possible names of the member to be imported.</param>
        /// <param name="isRequired"><c>true</c> if the build should fail if there no matching method in the target class, <c>false</c> to set <paramref name="aspectField"/> to <c>null</c> in this case.</param>
        /// <param name="order">Determines whether the <paramref name="aspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.
        /// </param>
        public ImportMethodAdviceInstance( FieldInfo aspectField, string[] methodNames, bool isRequired = false,
                                           ImportMemberOrder order = ImportMemberOrder.Default )
            : base( aspectField, order, isRequired )
        {
            if (methodNames == null || methodNames.Length == 0)
                throw new ArgumentNullException( nameof(methodNames));

            this.memberNames = methodNames;
        }

        /// <inheritdoc />
        public override object Member
        {
            get { return null; }
        }

        /// <inheritdoc />
        public override string[] MemberNames
        {
            get { return this.memberNames; }
        }
    }
}

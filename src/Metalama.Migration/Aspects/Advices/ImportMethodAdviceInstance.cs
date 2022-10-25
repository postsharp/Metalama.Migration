using System;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Represents an advises that import a method of the target class into the aspect class.
    /// </summary>
    public sealed class ImportMethodAdviceInstance : ImportMemberAdviceInstance
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportMethodAdviceInstance"/>.
        /// </summary>
        /// <param name="aspectField">A field of the aspect class into that will be assigned to a delegate of the imported method at runtime. The field type should be a delegate of the same signature than the method to import.</param>
        /// <param name="methodName">Name of the method to import.</param>
        /// <param name="isRequired"><c>true</c> if the build should fail if there no matching method in the target class, <c>false</c> to set <paramref name="aspectField"/> to <c>null</c> in this case.</param>
        /// <param name="order">Determines whether the <paramref name="aspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.
        /// </param>
        public ImportMethodAdviceInstance(
            FieldInfo aspectField,
            string methodName,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
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
        public ImportMethodAdviceInstance(
            FieldInfo aspectField,
            string[] methodNames,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override object Member { get; }

        /// <inheritdoc />
        public override string[] MemberNames { get; }
    }
}
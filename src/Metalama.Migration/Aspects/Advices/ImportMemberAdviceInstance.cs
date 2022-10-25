using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Base class for <see cref="ImportLocationAdviceInstance"/> and <see cref="ImportMethodAdviceInstance"/>.
    /// </summary>
    /// <seealso cref="IAdviceProvider"/>
    /// <seealso cref="ImportMemberAttribute"/>
    public abstract class ImportMemberAdviceInstance : AdviceInstance
    {
        /// <summary>
        /// Gets the field of the aspect class to which the field or property needs to be bound.
        /// </summary>
        public FieldInfo AspectField { get; }

        /// <summary>
        /// Determines whether a build-time error should be emitted if the member cannot be found.
        /// If <c>false</c>, the binding field will be <c>null</c> in case the imported member is absent.
        /// </summary>
        /// <remarks>
        /// <para>This property is always <c>true</c> when the <see cref="Member"/> property is set.</para>
        /// </remarks>
        public bool IsRequired { get; }

        /// <summary>
        /// Gets the reflection object (<see cref="LocationInfo"/> or <see cref="MethodInfo"/>) that needs to be
        /// imported, or <c>null</c> if the exact member is unknown and must be matched by name and signature.
        /// </summary>
        public abstract object Member { get; }

#pragma warning disable CA1819 // Properties should not return arrays (TODO)
        /// <summary>
        /// Gets the fallback list of possible names of the member to be imported.
        /// </summary>
        public abstract string[] MemberNames { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        /// <summary>
        /// Determines whether the <see cref="AspectField"/> should be bound to the member
        /// as resolved before or after introduction of new members into the target class by the current advise.
        /// </summary>
        public ImportMemberOrder Order { get; }

        /// <inheritdoc />
        public override object MasterAspectMember { get; }
    }
}
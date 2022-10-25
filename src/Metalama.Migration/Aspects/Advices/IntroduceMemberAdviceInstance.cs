using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Base class for <see cref="IntroduceMethodAdviceInstance"/>.
    /// </summary>
    public abstract class IntroduceMemberAdviceInstance : AdviceInstance
    {
        /// <summary>
        /// Gets the visibility of the introduced member.
        /// </summary>
        public Visibility Visibility { get; }

        /// <summary>
        /// Determines whether the introduced member should be virtual. 
        /// </summary>
        /// <remarks>
        ///   <para>
        ///     When this property is <c>false</c> and the member already exists in a base type
        ///     and is virtual, the member is overridden and marked as <c>sealed</c>.
        ///   </para>
        ///   <para>
        ///     When this property is set to <c>null</c>, the introduced member is <c>virtual</c> if it exists in a base
        ///     type as a virtual member, otherwise non-virtual.
        ///   </para>
        /// </remarks>
        public bool? IsVirtual { get; }

        /// <summary>
        ///   Determines the action to be overtaken when the member to be introduced already exists
        ///   in the type to which the aspect is applied, or to a base type.
        /// </summary>
        public MemberOverrideAction OverrideAction { get; }
    }
}
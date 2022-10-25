using Metalama.Framework.Aspects;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, call one of the <c>Introduce</c> methods of
    ///  <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.
    /// </summary>
    /// <seealso href="@introducing-members"/>
    public abstract class IntroduceMemberAdviceInstance : AdviceInstance
    {
        public Visibility Visibility { get; }

        public bool? IsVirtual { get; }

        public MemberOverrideAction OverrideAction { get; }
    }
}
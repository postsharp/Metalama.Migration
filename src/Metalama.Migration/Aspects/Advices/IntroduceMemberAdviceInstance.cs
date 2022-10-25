using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    public abstract class IntroduceMemberAdviceInstance : AdviceInstance
    {
        public Visibility Visibility { get; }

        public bool? IsVirtual { get; }

        public MemberOverrideAction OverrideAction { get; }
    }
}
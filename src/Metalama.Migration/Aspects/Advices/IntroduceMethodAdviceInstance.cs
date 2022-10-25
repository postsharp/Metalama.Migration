using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    public sealed class IntroduceMethodAdviceInstance : IntroduceMemberAdviceInstance
    {
        public IntroduceMethodAdviceInstance( MethodInfo method, Visibility visibility, bool? isVirtual, MemberOverrideAction overrideAction )
        {
            throw new NotImplementedException();
        }

        public override object MasterAspectMember { get; }
    }
}
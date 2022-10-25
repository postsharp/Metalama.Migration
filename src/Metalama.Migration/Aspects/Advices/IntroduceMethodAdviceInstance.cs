using System;
using System.Reflection;
using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, call the <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.IntroduceMethod"/> method.
    /// </summary>
    /// <seealso href="@introducing-members"/>
    public sealed class IntroduceMethodAdviceInstance : IntroduceMemberAdviceInstance
    {
        public IntroduceMethodAdviceInstance( MethodInfo method, Visibility visibility, bool? isVirtual, MemberOverrideAction overrideAction )
        {
            throw new NotImplementedException();
        }

        public override object MasterAspectMember { get; }
    }
}
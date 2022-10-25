using System;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage(
        AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method,
        AllowMultiple = false )]
    public sealed class IntroduceMemberAttribute : Advice
    {
        public Visibility Visibility { get; set; }

        public bool IsVirtual { get; set; }

        public bool IsIsVirtualSpecified { get; }

        public MemberOverrideAction OverrideAction { get; set; }
    }
}
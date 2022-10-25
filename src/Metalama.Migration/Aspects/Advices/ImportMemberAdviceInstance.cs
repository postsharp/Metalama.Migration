using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    public abstract class ImportMemberAdviceInstance : AdviceInstance
    {
        public FieldInfo AspectField { get; }

        public bool IsRequired { get; }

        public abstract object Member { get; }

#pragma warning disable CA1819 // Properties should not return arrays (TODO)

        public abstract string[] MemberNames { get; }
#pragma warning restore CA1819 // Properties should not return arrays

        public ImportMemberOrder Order { get; }

        public override object MasterAspectMember { get; }
    }
}
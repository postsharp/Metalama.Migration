using System;
using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    public sealed class ImportMethodAdviceInstance : ImportMemberAdviceInstance
    {
        public ImportMethodAdviceInstance(
            FieldInfo aspectField,
            string methodName,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public ImportMethodAdviceInstance(
            FieldInfo aspectField,
            string[] methodNames,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public override object Member { get; }

        public override string[] MemberNames { get; }
    }
}
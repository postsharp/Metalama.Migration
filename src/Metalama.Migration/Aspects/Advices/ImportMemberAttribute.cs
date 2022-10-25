using System;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Field, AllowMultiple = false )]
    public sealed class ImportMemberAttribute : Advice
    {
        public ImportMemberAttribute( params string[] memberNames )
        {
            MemberNames = memberNames;
        }

        public ImportMemberAttribute( string memberName )
        {
            MemberNames = new[] { memberName };
        }

        public bool IsRequired { get; set; }

        public string[] MemberNames { get; }

        public ImportMemberOrder Order { get; set; }
    }
}
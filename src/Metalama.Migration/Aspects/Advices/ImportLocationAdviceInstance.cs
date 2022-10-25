using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Advices
{
    public sealed class ImportLocationAdviceInstance : ImportMemberAdviceInstance
    {
        public ImportLocationAdviceInstance( FieldInfo aspectField, LocationInfo location )
        {
            throw new NotImplementedException();
        }

        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string propertyName,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public ImportLocationAdviceInstance(
            FieldInfo aspectField,
            string[] propertyNames,
            bool isRequired = false,
            ImportMemberOrder order = ImportMemberOrder.Default )
        {
            throw new NotImplementedException();
        }

        public LocationInfo Location { get; }

        public override object Member { get; }

        public override string[] MemberNames { get; }
    }
}
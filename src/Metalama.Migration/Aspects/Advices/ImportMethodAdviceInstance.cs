using System;
using System.Reflection;
using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, members of the target declaration do not need to be imported into the aspect. Instead, the
    /// aspect accesses the target code using dynamic code or invokers. To generate code that calls a method, use <see cref="IMethod"/>.<see cref="IMethod.Invokers"/>.
    /// </summary>
    /// <seealso href="template-dynamic-code"/>
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
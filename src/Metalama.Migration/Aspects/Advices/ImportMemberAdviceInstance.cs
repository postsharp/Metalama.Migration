// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, members of the target declaration do not need to be imported into the aspect. Instead, the
    /// aspect accesses the target code using dynamic code or invokers.
    /// </summary>
    /// <seealso href="template-dynamic-code"/>
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
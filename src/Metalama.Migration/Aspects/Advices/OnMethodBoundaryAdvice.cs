// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Advising;
using Metalama.Framework.Aspects;

#pragma warning disable 3015   // CLS Compliance
#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, implement the <see cref="IAspect{T}.BuildAspect"/> method and use <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Advice"/>.<see cref="IAdviceFactory.Override(Metalama.Framework.Code.IMethod,in Metalama.Framework.Aspects.MethodTemplateSelector,object?,object?)"/>.
    /// </summary>
    /// <seealso href="@overriding-methods"/>
    public abstract class OnMethodBoundaryAdvice : GroupingAdvice
    {
        /// <summary>
        /// In Metalama, use the different properties of <see cref="MethodTemplateSelector"/>.
        /// </summary>
        public SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        public UnsupportedTargetAction UnsupportedTargetAction { get; set; }
    }
}
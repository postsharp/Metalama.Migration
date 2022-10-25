// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Configuration;

#pragma warning disable 3015 // CLS Compliance
#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Base class for <see cref="OnMethodEntryAdvice"/>, <see cref="OnMethodExceptionAdvice"/>,
    /// <see cref="OnMethodSuccessAdvice"/> or <see cref="OnMethodExitAdvice"/>.
    /// </summary>
    /// <remarks>
    /// </remarks>
    public abstract class OnMethodBoundaryAdvice : GroupingAdvice
    {
        private SemanticallyAdvisedMethodKinds semanticallyAdvisedMethods = SemanticallyAdvisedMethodKinds.Default;
        private UnsupportedTargetAction unsupportedTargetAction = UnsupportedTargetAction.Default;

        internal OnMethodBoundaryAdvice()
        {
            
        }

        /// <summary>
        /// Determines which target methods will be advised semantically. This affects the behavior of the advice when it's applied to
        /// iterator or async methods, which are compiled into state machines.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Semantic advising results in an aspect that is consistent with the level of abstraction of the programming language. This is the default behavior.
        /// You can disable semantic advising using this property to be consistent with the level of abstraction
        /// of MSIL and for backward-compatibility with the versions of PostSharp prior to 3.1.
        /// </para>
        /// </remarks>
        public SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds
        {
            get { return this.semanticallyAdvisedMethods; }
            set { this.semanticallyAdvisedMethods = value; }
        }

        /// <summary>
        /// Specifies the action to take when the advice is applied to an unsupported target method.
        /// </summary>
        public UnsupportedTargetAction UnsupportedTargetAction
        {
            get { return this.unsupportedTargetAction; }
            set { this.unsupportedTargetAction = value; }
        }
    }
}

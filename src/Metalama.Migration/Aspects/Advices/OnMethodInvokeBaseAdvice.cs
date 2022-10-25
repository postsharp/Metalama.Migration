// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
#pragma warning disable CA1710 // Identifiers should have correct suffix


namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// The base class for method interception advices.
    /// </summary>
    public abstract class OnMethodInvokeBaseAdvice : GroupingAdvice
    {
        private SemanticallyAdvisedMethodKinds semanticallyAdvisedMethodKinds = SemanticallyAdvisedMethodKinds.Default;
        private UnsupportedTargetAction unsupportedTargetAction = UnsupportedTargetAction.Default;

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
            get { return this.semanticallyAdvisedMethodKinds; }
            set { this.semanticallyAdvisedMethodKinds = value; }
        }

        /// <summary>
        /// Specifies the action to take when the advice is applied to an async method with unsupported return value type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Starting with C#7 async methods can have return types other than <see cref="System.Threading.Tasks.Task"/> or <see cref="System.Threading.Tasks.Task{TResult}"/>.
        /// Async method interception does not support this type of async methods. By default, the build error is raised whenever
        /// async method interception is applied to a method that returns awaitable type other than <see cref="System.Threading.Tasks.Task"/> or <see cref="System.Threading.Tasks.Task{TResult}"/>.
        /// </para>
        /// <para>
        /// Set this property to change how unsupported async methods are handled during compile time.
        /// </para>
        /// </remarks>
        public UnsupportedTargetAction UnsupportedTargetAction
        {
            get { return this.unsupportedTargetAction; }
            set { this.unsupportedTargetAction = value; }
        }
    }
}

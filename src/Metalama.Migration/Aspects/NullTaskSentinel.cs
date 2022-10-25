// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Aspects
{
    /// <summary>
    /// The singleton instance of this class is assigned to the <see cref="MethodExecutionArgs.ReturnValue"/> property when
    /// an <see cref="OnMethodBoundaryAspect"/> aspect is applied semantically to a method and the target method returns a null task.
    /// </summary>
    /// <remarks>
    /// When an <see cref="OnMethodBoundaryAspect"/> aspect is applied semantically to a method, then the <see cref="MethodExecutionArgs.ReturnValue"/> property
    /// represents the result of executing the task returned by the method. If the method returns a null task, then the result is undefined. The <see cref="NullTaskSentinel.Instance"/>
    /// is used to represent this case.
    /// </remarks>
    public sealed class NullTaskSentinel
    {
        static NullTaskSentinel()
        {
            Instance = new NullTaskSentinel();
        }

        /// <summary>
        /// The singleton instance that is assigned to the <see cref="MethodExecutionArgs.ReturnValue"/> property when
        /// an <see cref="OnMethodBoundaryAspect"/> aspect is applied semantically to a method and the target method returns a null task.
        /// </summary>
        public static NullTaskSentinel Instance { get; }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Enumerates possible target methods for semantic advising.
    /// </summary>
    /// <remarks>
    /// When semantic advising is enabled the advices work at the abstraction level of the original programming language.
    /// For example, advices are applied to the underlying async state machine instead of the public async method the starts the state machine.
    /// </remarks>
    [Flags]
    public enum SemanticallyAdvisedMethodKinds
    {
        /// <summary>
        /// Do not use semantic advising.
        /// </summary>
        None = 0,

        /// <summary>
        /// Apply semantic advising to async methods.
        /// </summary>
        Async = 1 << 0,

        /// <summary>
        /// Apply semantic advising to methods that return any awaitable type (e.g. <c>System.Threading.Tasks.Task</c>).
        /// </summary>
        ReturnsAwaitable = 1 << 1,

        /// <summary>
        /// Apply semantic advising to iterator methods (methods that use <c>yield</c> statements).
        /// </summary>
        Iterator = 1 << 2,

        /// <summary>
        /// Apply semantic advising to methods that return <see cref="IEnumerable"/>, <see cref="IEnumerator"/>, <see cref="IEnumerable{T}"/>, or
        /// <see cref="IEnumerator{T}"/>.
        /// </summary>
        ReturnsEnumerable = 1 << 3,

        /// <summary>
        /// Apply semantic advising to async methods which return IAsyncEnumerable. Semantic advising for this C# 8.0 feature is not supported by PostSharp yet.
        /// </summary>
        AsyncIterator = 1 << 4,

        /// <summary>
        /// The default behavior includes <see cref="Async"/>, <see cref="ReturnsAwaitable"/>, <see cref="Iterator"/>, and <see cref="AsyncIterator" />, but not <see cref="ReturnsEnumerable"/>.
        /// </summary>
        Default = Async | ReturnsAwaitable | Iterator | AsyncIterator,

        /// <summary>
        /// Apply semantic advising to all possible target methods.
        /// </summary>
        All = Default | ReturnsEnumerable
    }
}
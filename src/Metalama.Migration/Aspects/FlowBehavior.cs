// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Enumerates the possible behaviors of the calling method after the calling method has returned.
    /// </summary>
    /// <remarks>
    /// <para>
    ///   This enumeration is used by the <see cref = "MethodExecutionArgs" /> class.
    /// </para>
    /// </remarks>
    public enum FlowBehavior
    {
        /// <summary>
        ///   Default flow behavior for the current method. The default flow is <see cref = "Continue" /> for all advices except for
        /// <see cref="OnMethodBoundaryAspect.OnException"/> where it is <see cref = "RethrowException" />.
        /// </summary>
        Default = 0,

        /// <summary>
        ///   Continue normal method execution. For <see cref="OnMethodBoundaryAspect.OnException"/> advice,
        ///   the <see cref="Continue"/> behavior works the same way as <see cref="Return"/> behavior.
        /// </summary>
        Continue = 1,

        /// <summary>
        ///   The current exception will be rethrown. Available only for <see cref="OnMethodBoundaryAspect.OnException"/>.
        /// </summary>
        RethrowException = 2,

        /// <summary>
        ///   Return immediately from the current method. Available only for <see cref="OnMethodBoundaryAspect.OnEntry"/> and
        ///   <see cref="OnMethodBoundaryAspect.OnException"/>. Note that you may want to set the <see cref = "MethodExecutionArgs.ReturnValue" />
        ///   property, otherwise you may get a <see cref = "NullReferenceException" />. If there is another <see cref="OnMethodBoundaryAspect"/>
        ///   aspect before the current <see cref="OnMethodBoundaryAspect"/> aspect on the current method,
        ///   the <see cref="Return"/> behavior calls the <see cref="OnMethodBoundaryAspect.OnSuccess"/>
        ///   and <see cref="OnMethodBoundaryAspect.OnExit"/> methods of the other aspect.
        /// </summary>
        /// <remarks>
        ///   If the advice is applied semantically to an iterator method in <see cref="OnMethodBoundaryAspect.OnEntry"/>, it means that
        /// the call to <see cref="IEnumerator.MoveNext"/> should return false and the enumerator should thus behave as empty.
        /// </remarks>
        Return = 3,

        /// <summary>
        /// Throws the exception contained in the <see cref="MethodExecutionArgs.Exception"/> property. Available only for <see cref="OnMethodBoundaryAspect.OnException"/>.
        /// </summary>
        ThrowException = 4,

        /// <summary>
        /// Awaits for an awaiter. Available only for
        /// <see cref="OnMethodBoundaryAspect.OnEntry"/> and <see cref="OnMethodBoundaryAspect.OnResume"/> advices
        /// applied to async methods.
        /// </summary>
        /// <remarks>
        /// In the future, this may also cause a value to be yielded in iterator methods. Currently, it is the same as <see cref="Continue"/> for iterator methods.
        /// </remarks>
        Yield = 5
    }
}
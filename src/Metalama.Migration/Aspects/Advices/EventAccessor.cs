// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Defines the signature of methods implementing the <see cref = "Event{T}.Add" />
    ///   and <see cref = "Event{T}.Remove" /> semantics of an event.
    /// </summary>
    /// <typeparam name = "TDelegate">Handler type (derived from <see cref = "Delegate" />).</typeparam>
    /// <param name = "delegate">Handler.</param>
    /// <seealso cref = "Event{T}" />
    public delegate void EventAccessor<TDelegate>( TDelegate @delegate );
}

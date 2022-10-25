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
using System;
using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In PostSharp, a binding was a run-time object that allowed the run-time code of the aspect to call the target code. In Metalama, aspects no longer
    /// have run-time code. Instead, they have templates that are expanded at compile time and generate run-time code. Templates can generate run-time code
    /// that accesses target code using dynamic code or invokers. For events, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Event"/>.<see cref="IEvent.Invokers"/>.
    /// </summary>
    [InternalImplement]
    public interface IEventBinding
    {
        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Event"/>.<see cref="IEvent.Invokers"/>.
        /// </summary>
        void AddHandler( ref object instance, Delegate handler );

        /// <summary>
        /// In Metalama, use <see cref="meta"/>.<see cref="meta.Target"/>.<see cref="IMetaTarget.Event"/>.<see cref="IEvent.Invokers"/>.
        /// </summary>
        void RemoveHandler( ref object instance, Delegate handler );

        /// <summary>
        /// In Metalama, generate run-time code that invokes the handler.
        /// </summary>
        object InvokeHandler( ref object instance, Delegate handler, Arguments arguments );
    }
}
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Exposes the semantics of an event for use with the <see cref="ImportMemberAttribute"/> aspect extension.
    /// </summary>
    /// <typeparam name="TDelegate">Handler type (derived from <see cref="Delegate"/>).</typeparam>
    /// <remarks>
    /// </remarks>
    /// <seealso cref="ImportMemberAttribute"/>
    /// <include file="../Documentation.xml" path="/documentation/section[@name='seeAlsoIntroduceImportMembers']/*"/>
    public sealed class Event<TDelegate>
    {
        /// <exclude />
        public Event( EventAccessor<TDelegate> addDelegate, EventAccessor<TDelegate> removeDelegate )
        {
            Add = addDelegate;
            Remove = removeDelegate;
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>add</b> accessor
        ///   of the imported event.
        /// </summary>
        public EventAccessor<TDelegate> Add { get; }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>remove</b> accessor
        ///   of the imported event.
        /// </summary>
        public EventAccessor<TDelegate> Remove { get; }
    }
}
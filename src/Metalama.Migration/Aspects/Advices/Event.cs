// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

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
#if SERIALIZABLE
    [Serializable]
#endif
    public sealed class Event<TDelegate>
    {
        /// <exclude />
        public Event( EventAccessor<TDelegate> addDelegate, EventAccessor<TDelegate> removeDelegate )
        {
            this.Add = addDelegate;
            this.Remove = removeDelegate;
        }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>add</b> accessor
        ///   of the imported event.
        /// </summary>
        public EventAccessor<TDelegate> Add { get; private set; }

        /// <summary>
        ///   Gets a delegate enabling to invoke the <b>remove</b> accessor
        ///   of the imported event.
        /// </summary>
        public EventAccessor<TDelegate> Remove { get; private set; }
    }
}
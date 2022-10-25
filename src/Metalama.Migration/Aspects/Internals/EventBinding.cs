// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public abstract class EventBinding : IEventBinding
    {
        /// <exclude />
        public virtual void AddHandler( ref object instance, Delegate handler, object reserved )
        {
            throw new NotSupportedException();
        }

        /// <exclude />
        public virtual void RemoveHandler( ref object instance, Delegate handler, object reserved )
        {
            throw new NotSupportedException();
        }

        /// <exclude />
        public virtual object InvokeHandler( ref object instance, Delegate handler, Arguments arguments, object reserved )
        {
            throw new NotSupportedException();
        }

        /// <exclude />
        void IEventBinding.AddHandler( ref object instance, Delegate handler )
        {
            this.AddHandler( ref instance, handler, null );
        }

        /// <exclude />
        void IEventBinding.RemoveHandler( ref object instance, Delegate handler )
        {
            this.RemoveHandler( ref instance, handler, null );
        }

        /// <exclude />
        object IEventBinding.InvokeHandler( ref object instance, Delegate handler, Arguments arguments )
        {
            return this.InvokeHandler( ref instance, handler, arguments, null );
        }
    }
}
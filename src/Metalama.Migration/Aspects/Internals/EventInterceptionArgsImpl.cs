// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

#pragma warning disable CA1051 // Do not declare visible instance fields.

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [Internal]
    [DebuggerNonUserCode]
    [DebuggerStepThrough]
    public sealed class EventInterceptionArgsImpl : EventInterceptionArgs
    {
        /// <exclude />
        public EventInterceptionArgsImpl( object instance, Arguments arguments, Delegate handler ) : base( instance, arguments, handler )
        {
        }

        /// <exclude />
        public EventBinding TypedBinding;

        /// <exclude />
        public override IEventBinding Binding
        {
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override void ProceedAddHandler()
        {
            this.TypedBinding.AddHandler( ref this.InstanceField, this.Handler, this );
        }

        /// <exclude />
        public override void ProceedRemoveHandler()
        {
            this.TypedBinding.RemoveHandler( ref this.InstanceField, this.Handler, this );
        }

        /// <exclude />
        public override void ProceedInvokeHandler()
        {
            this.ReturnValue = this.TypedBinding.InvokeHandler( ref this.InstanceField, this.Handler, this.Arguments, this );
        }

        /// <exclude />
        public override void AddHandler( Delegate handler )
        {
            this.TypedBinding.AddHandler( ref this.InstanceField, handler, this );
        }

        /// <exclude />
        public override void RemoveHandler( Delegate handler )
        {
            this.TypedBinding.RemoveHandler( ref this.InstanceField, handler, this );
        }

        /// <exclude />
        public override object InvokeHandler( Delegate handler, Arguments arguments )
        {
            return this.TypedBinding.InvokeHandler( ref this.InstanceField, handler, arguments, this );
        }
    }
}
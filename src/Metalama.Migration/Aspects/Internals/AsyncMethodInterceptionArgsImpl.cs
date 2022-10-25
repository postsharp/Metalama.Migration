// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

#if ASYNCAWAIT

#pragma warning disable CA1051 // Do not declare visible instance fields.

using System;
using System.Diagnostics;
using PostSharp.Constraints;
using System.Threading.Tasks;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class AsyncMethodInterceptionArgsImpl : MethodInterceptionArgs, IAsyncMethodInterceptionArgsInternal, ITaskAdapter
    {
        /// <exclude />
        public AsyncMethodInterceptionArgsImpl( object instance, Arguments arguments )
            : base( instance, arguments )
        {
        }

        /// <exclude />
        public AsyncMethodBinding TypedBinding;

        /// <exclude />
        public override IMethodBinding Binding
        {
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override IAsyncMethodBinding AsyncBinding
        {
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override object ReturnValue
        {
            get { return null; }
            set { }
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodInterceptionProceedAwaitable ProceedAsync()
        {
            Task task = this.TypedBinding.InvokeAsync( ref this.InstanceField, this.Arguments, this );
            return new MethodInterceptionProceedAwaitable( task, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments )
        {
            Task task = this.TypedBinding.InvokeAsync( ref this.InstanceField, arguments, this );
            return new MethodBindingInvokeAwaitable( task, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override void Proceed()
        {
            throw new InvalidOperationException( "The Proceed method is not available in the async interception advice. Use the ProceedAsync method." );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override object Invoke( Arguments arguments )
        {
            throw new InvalidOperationException( "The Invoke method is not available in the async interception advice. the Use InvokeAsync method." );
        }

        /// <exclude />
        void IAsyncMethodInterceptionArgsInternal.GetResult( Task task )
        {
        }

        /// <exclude />
        Task IAsyncMethodInterceptionArgsInternal.AwaitResult( Task task )
        {
            return task;
        }

        /// <exclude />
        object ITaskAdapter.GetResult( Task task )
        {
            return null;
        }

        /// <exclude />
        public override bool IsAsync { get { return true; } }
    }

    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class AsyncMethodInterceptionArgsImpl<TReturnValue> : MethodInterceptionArgs, IAsyncMethodInterceptionArgsInternal, ITaskAdapter
    {
        /// <exclude />
        public AsyncMethodInterceptionArgsImpl( object instance, Arguments arguments )
            : base( instance, arguments )
        {
        }

        /// <exclude />
        public AsyncMethodBinding<TReturnValue> TypedBinding;

        /// <exclude />
        public TReturnValue TypedReturnValue;

        /// <exclude />
        public override IMethodBinding Binding
        {
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override IAsyncMethodBinding AsyncBinding
        {
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override object ReturnValue
        {
            get { return this.TypedReturnValue; }
            set { this.TypedReturnValue = (TReturnValue) value; }
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodInterceptionProceedAwaitable ProceedAsync()
        {
            Task task = this.TypedBinding.InvokeAsync( ref this.InstanceField, this.Arguments, this );
            return new MethodInterceptionProceedAwaitable( task, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments )
        {
            Task task = this.TypedBinding.InvokeAsync( ref this.InstanceField, arguments, this );
            return new MethodBindingInvokeAwaitable( task, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override void Proceed()
        {
            throw new InvalidOperationException( "The Proceed method is not available in the async interception advice. Use the ProceedAsync method." );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override object Invoke( Arguments arguments )
        {
            throw new InvalidOperationException( "The Invoke method is not available in the async interception advice. the Use InvokeAsync method." );
        }

        /// <exclude />
        public override bool IsAsync { get { return true; } }

        /// <exclude />
        void IAsyncMethodInterceptionArgsInternal.GetResult( Task task )
        {
            this.TypedReturnValue = ((Task<TReturnValue>) task).Result;
        }

        /// <exclude />
        async Task IAsyncMethodInterceptionArgsInternal.AwaitResult( Task task )
        {
            this.TypedReturnValue = await (Task<TReturnValue>) task;
        }

        /// <exclude />
        object ITaskAdapter.GetResult( Task task )
        {
            return ((Task<TReturnValue>) task).Result;
        }
    }
}

#endif
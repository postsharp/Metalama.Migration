// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

#pragma warning disable CA1051 // Do not declare visible instance fields.

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class MethodInterceptionArgsImpl : MethodInterceptionArgs
    {
        /// <exclude />
        public MethodInterceptionArgsImpl( object instance, Arguments arguments )
            : base( instance, arguments )
        {
        }

        /// <exclude />
        public MethodBinding TypedBinding;

        /// <exclude />
        public override IMethodBinding Binding
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
        public override void Proceed()
        {
            this.TypedBinding.Invoke( ref this.InstanceField, this.Arguments, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override object Invoke( Arguments arguments )
        {
            this.TypedBinding.Invoke( ref this.InstanceField, arguments, this );
            return null;
        }

#if ASYNCAWAIT
        /// <exclude />
        public override bool IsAsync { get { return false; } }

        /// <exclude />
        public override IAsyncMethodBinding AsyncBinding
        {
            get { throw new InvalidOperationException( "The AsyncBinding property is not available in the non-async interception advice. Use the Binding property instead." ); }
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodInterceptionProceedAwaitable ProceedAsync()
        {
            throw new InvalidOperationException( "The ProceedAsync method is not available in the non-async interception advice. Use the Proceed method instead." );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments )
        {
            throw new InvalidOperationException( "The InvokeAsync method is not available in the non-async interception advice. Use the Invoke method instead." );
        }
#endif
    }

    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class MethodInterceptionArgsImpl<TReturnValue> : MethodInterceptionArgs
    {
        /// <exclude />
        public MethodInterceptionArgsImpl( object instance, Arguments arguments )
            : base( instance, arguments )
        {
        }

        /// <exclude />
        public MethodBinding<TReturnValue> TypedBinding;

        /// <exclude />
        public TReturnValue TypedReturnValue;

        /// <exclude />
        public override IMethodBinding Binding
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
        public override void Proceed()
        {
            this.TypedReturnValue = this.TypedBinding.Invoke( ref this.InstanceField, this.Arguments, this );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override object Invoke( Arguments arguments )
        {
            return this.TypedBinding.Invoke( ref this.InstanceField, arguments, this );
        }

#if ASYNCAWAIT
        /// <exclude />
        public override bool IsAsync { get { return false; } }

        /// <exclude />
        public override IAsyncMethodBinding AsyncBinding
        {
            get { throw new InvalidOperationException( "The AsyncBinding property is not available in the non-async interception advice. Use the Binding property instead." ); }
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodInterceptionProceedAwaitable ProceedAsync()
        {
            throw new InvalidOperationException( "The ProceedAsync method is not available in the non-async interception advice. Use the Proceed method instead." );
        }

        /// <exclude />
        [DebuggerAspectGeneratedCode]
        public override MethodBindingInvokeAwaitable InvokeAsync( Arguments arguments )
        {
            throw new InvalidOperationException( "The InvokeAsync method is not available in the non-async interception advice. Use the Invoke method instead." );
        }
#endif
    }
}
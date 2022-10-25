// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Diagnostics;
using PostSharp.Constraints;

#pragma warning disable CA1051 // Do not declare visible instance fields.

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class LocationInterceptionArgsImpl<T> : LocationInterceptionArgs, ILocationInterceptionArgs<T>
    {
        /// <exclude />
        public LocationInterceptionArgsImpl( object instance, Arguments index )
            : base( instance, index )
        {
        }

        /// <exclude />
        public LocationBinding<T> TypedBinding;

        /// <exclude />
        public override ILocationBinding Binding
        {
            get { return this.TypedBinding; }
        }

        T ILocationInterceptionArgs<T>.Value
        {
            [DebuggerHidden]
            get { return this.TypedValue; }
            [DebuggerHidden]
            set { this.TypedValue = value; }
        }

        ILocationBinding<T> ILocationInterceptionArgs<T>.Binding
        {
            [DebuggerHidden]
            get { return this.TypedBinding; }
        }

        /// <exclude />
        public override object Value
        {
            get { return this.TypedValue; }
            set { this.TypedValue = (T) value; }
        }

        /// <exclude />
        public T TypedValue;

        /// <exclude />
        public override void ProceedGetValue()
        {
            this.TypedValue = this.TypedBinding.GetValue( ref this.InstanceField, this.Index, this );
        }

        /// <exclude />
        public override void ProceedSetValue()
        {
            this.TypedBinding.SetValue( ref this.InstanceField, this.Index, this.TypedValue, this );
        }

        T ILocationInterceptionArgs<T>.GetCurrentValue()
        {
            return this.GetCurrentValueCore();
        }

        private T GetCurrentValueCore()
        {
            T value = this.TypedValue;
            try
            {
                return this.TypedBinding.GetValue( ref this.InstanceField, this.Index, this );
            }
            finally
            {
                this.TypedValue = value;
            }
        }

        void ILocationInterceptionArgs<T>.SetNewValue( T value )
        {
            this.SetNewValueCore( value );
        }

        private void SetNewValueCore( T value )
        {
            this.TypedBinding.SetValue( ref this.InstanceField, this.Index, value, this );
        }

        /// <exclude />
        public override object GetCurrentValue()
        {
            return this.GetCurrentValueCore();
        }

        /// <exclude />
        public override void SetNewValue( object value )
        {
            this.SetNewValueCore( (T) value );
        }

        /// <exclude />
        public override void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload )
        {
            action.Execute( this, ref payload );
        }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;
using PostSharp.Reflection;

namespace PostSharp.Aspects.Internals
{
    /// <exclude />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public abstract class LocationBinding<T> : ILocationBinding<T>
    {
        /// <exclude />
        public virtual T GetValue( ref object instance, Arguments index, object reserved )
        {
            throw new NotSupportedException();
        }

        /// <exclude />
        public virtual void SetValue( ref object instance, Arguments index, T value, object reserved )
        {
            // Error message is probably correct, though I suspect there can be more reasons why we reach this place.
            throw new NotSupportedException("The field or property is read-only.");
        }

        /// <exclude />
        object ILocationBinding.GetValue( ref object instance, Arguments index )
        {
            return this.GetValue( ref instance, index, null );
        }

        /// <exclude />
        void ILocationBinding<T>.SetValue( ref object instance, Arguments index, T value )
        {
            this.SetValue( ref instance, index, value, null );
        }

        /// <exclude />
        T ILocationBinding<T>.GetValue( ref object instance, Arguments index )
        {
            return this.GetValue( ref instance, index, null );
        }

        /// <exclude />
        void ILocationBinding.SetValue( ref object instance, Arguments index, object value )
        {
            this.SetValue( ref instance, index, (T) value, null );
        }

        /// <exclude />
        public virtual LocationInfo LocationInfo { get { return null; } }

        /// <exclude />
        public Type LocationType
        {
            get { return typeof(T); }
        }

        /// <inheritdoc />
        public abstract DeclarationIdentifier DeclarationIdentifier { get; }

        /// <inheritdoc />
        public void Execute<TPayload>( ILocationBindingAction<TPayload> action, ref TPayload payload )
        {
            action.Execute( this, ref payload );
        }
    }
}
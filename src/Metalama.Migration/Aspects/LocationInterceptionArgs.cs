// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Collections.Generic;
using System.Diagnostics;
using PostSharp.Aspects.Internals;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Arguments of advices of aspect type <see cref = "LocationInterceptionAspect" />.
    /// </summary>
    /// <remarks>
    ///   <include file = "Documentation.xml" path = "/documentation/section[@name='aspectArgs']/*" />
    /// </remarks>
    /// <seealso cref = "LocationInterceptionAspect" />
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public abstract class LocationInterceptionArgs : LocationLevelAdviceArgs, ILocationInterceptionArgs
    {
        [DebuggerHidden]
        internal LocationInterceptionArgs( object instance, Arguments index )
            : base( instance )
        {
            this.Index = index;
        }

        /// <inheritdoc />
        public abstract ILocationBinding Binding
        {
            [DebuggerHidden]
            get;
        }

        /// <inheritdoc />
        public Arguments Index
        {
            [DebuggerHidden]
            get;
            [DebuggerHidden]
            private set;
        }


        /// <inheritdoc />
        public abstract void ProceedGetValue();

        /// <inheritdoc />
        public abstract void ProceedSetValue();

        /// <inheritdoc />
        public abstract object GetCurrentValue();

        /// <inheritdoc />
        public abstract void SetNewValue( object value );
        
        /// <inheritdoc />
        public abstract void Execute<TPayload>( ILocationInterceptionArgsAction<TPayload> action, ref TPayload payload );
    }
}
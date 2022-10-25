// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Aspects.Internals;
using PostSharp.Constraints;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Represents information about a location that has just been initialized. Used in <see cref="LocationInterceptionAspect.OnInstanceLocationInitialized"/>.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class LocationInitializationArgs : LocationLevelAdviceArgs
    {
        private readonly object backingFieldValue;

        /// <exclude />
        [DebuggerHidden]
        public LocationInitializationArgs( object instance, object backingFieldValue )
            : base( instance )
        {
            this.backingFieldValue = backingFieldValue;
        }

        /// <summary>
        /// Gets the initial value of the location.
        /// </summary>
        /// <remarks>
        /// Returns the current value of the field or, if it's a property, of the property's backing field. This is usually the default value or the value
        /// set by the initializer.
        /// </remarks>
        public override object Value
        {
            get => this.backingFieldValue;
            set =>
                throw new NotSupportedException(
                    $"You cannot change the Value in {nameof(IOnInstanceLocationInitializedAspect.OnInstanceLocationInitialized)}." );
        }
    }
}
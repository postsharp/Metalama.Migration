using System;
using System.Diagnostics;
using PostSharp.Aspects.Internals;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Represents information about a location that has just been initialized. Used in <see cref="LocationInterceptionAspect.OnInstanceLocationInitialized"/>.
    /// </summary>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class LocationInitializationArgs : LocationLevelAdviceArgs
    {
        /// <exclude />
        public LocationInitializationArgs( object instance, object backingFieldValue )
            : base( instance )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the initial value of the location.
        /// </summary>
        /// <remarks>
        /// Returns the current value of the field or, if it's a property, of the property's backing field. This is usually the default value or the value
        /// set by the initializer.
        /// </remarks>
        public override object Value { get; set; }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

namespace PostSharp.Aspects.Internals
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    /// <summary>
    ///   Implementation of <see cref = "Aspects.Arguments" /> representing a
    ///   list of arguments of arbitrary length and type.
    /// </summary>
    /// <remarks>
    ///   Unless generic implementations of
    ///   <see cref = "Aspects.Arguments" />, <see cref = "ArgumentsArray" /> boxes all arguments
    ///   into an <see cref = "Array" />, resulting in lower performance and higher memory usage.
    /// </remarks>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public sealed class ArgumentsArray : Arguments
    {
        private object[] arguments;

        /// <summary>
        ///   Initializes a new <see cref = "ArgumentsArray" />.
        /// </summary>
        /// <param name = "arguments"><see cref = "Array" /> containing the argument values.</param>
        public ArgumentsArray( object[] arguments )
            : base( arguments.Length )
        {
            this.arguments = arguments;
        }

        /// <summary>
        ///   Gets or sets the underlying array of arguments.
        /// </summary>
        /// <remarks>
        ///   When you set this property, the new <see cref = "Array" /> must have the same length as the previous one.
        /// </remarks>
        #pragma warning disable CA1819 // Properties should not return arrays (TODO)
        public object[] Arguments
        #pragma warning restore CA1819 // Properties should not return arrays (TODO)
        {
            get { return this.arguments; }
            set
            {
                if ( value == null )
                    throw new ArgumentNullException( nameof(value));
                if ( this.arguments != null && this.arguments.Length != value.Length )
                    throw new ArgumentOutOfRangeException( nameof(value), "The array has an invalid size." );
                this.arguments = value;
            }
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            return this.arguments[index];
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            this.arguments[index] = value;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));

            array.CopyTo( this.arguments, index );
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            this.arguments.CopyTo( array, index );
        }
    }
}

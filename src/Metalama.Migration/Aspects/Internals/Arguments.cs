// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

#pragma warning disable CA1710 // Identifiers should have correct suffix
#pragma warning disable CA1051 // Do not declare visible instance fields

namespace PostSharp.Aspects.Internals
{
    /// <summary>
    ///   Implementation of <see cref = "Arguments" /> representing a list of 1 argument.
    /// </summary>
    /// <typeparam name = "TArg0">Type of the first argument.</typeparam>
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Internal]
    public class Arguments<TArg0> : Arguments
    {
        private const int count = 1;

        /// <summary>
        ///   First Argument.
        /// </summary>
        public TArg0 Arg0;

        /// <summary>
        ///   Initializes a new <see cref = "Arguments{TArg0}" />.
        /// </summary>
        public Arguments()
            : base( count )
        {
        }

        /// <inheritdoc />
        public override object GetArgument( int index )
        {
            switch ( index )
            {
                case 0:
                    return this.Arg0;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void SetArgument( int index, object value )
        {
            switch ( index )
            {
                case 0:
                    this.Arg0 = (TArg0) value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException( nameof(index));
            }
        }

        /// <inheritdoc />
        public override void CopyTo( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            array[index] = this.Arg0;
        }

        /// <inheritdoc />
        public override void CopyFrom( object[] array, int index )
        {
            if ( array == null ) throw new ArgumentNullException( nameof(array));
            if ( array.Length + index < count )
                throw new ArgumentOutOfRangeException( nameof(array), "The array is not large enough." );
            this.Arg0 = (TArg0) array[index];
        }
    }
}

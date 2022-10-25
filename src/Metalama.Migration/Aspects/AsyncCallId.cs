// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Threading;
using PostSharp.Constraints;
using System.Globalization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Identifier of an asynchronous method invocation, i.e. of a unique async state machine instance.
    /// </summary>
    public struct AsyncCallId : IEquatable<AsyncCallId>
    {
        private static long counter;
        private readonly long id;

        private AsyncCallId( long id )
        {
            this.id = id;
        }

        /// <summary>
        /// Determines whether the current <see cref="AsyncCallId"/> is null.
        /// </summary>
        public bool IsNull => this.id == 0;

        /// <summary>
        /// Gets a null instance of the <see cref="AsyncCallId"/> struct.
        /// </summary>
        public static AsyncCallId Null => default(AsyncCallId);

        /// <exclude/>
        [Internal]
        public static AsyncCallId GetNext()
        {
            return new AsyncCallId( Interlocked.Increment( ref counter ) );
        }

        /// <inheritdoc/>
        public bool Equals( AsyncCallId other )
        {
            return Equals( this.id, other.id );
        }

        /// <inheritdoc/>
        public override bool Equals( object obj )
        {
            if ( ReferenceEquals( null, obj ) )
                return false;
            return obj is AsyncCallId && this.Equals( (AsyncCallId) obj );
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        /// <summary>
        /// Determines whether two instances of the <see cref="AsyncCallId"/> type are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==( AsyncCallId left, AsyncCallId right )
        {
            return left.Equals( right );
        }

        /// <summary>
        /// Determines whether two instances of the <see cref="AsyncCallId"/> type are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=( AsyncCallId left, AsyncCallId right )
        {
            return !left.Equals( right );
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if ( this.id == 0 )
                return "null";
            else
                return this.id.ToString(CultureInfo.InvariantCulture);
        }
    }
}

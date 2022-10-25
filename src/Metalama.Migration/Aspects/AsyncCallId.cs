using System;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Identifier of an asynchronous method invocation, i.e. of a unique async state machine instance.
    /// </summary>
    public struct AsyncCallId : IEquatable<AsyncCallId>
    {
        /// <summary>
        /// Determines whether the current <see cref="AsyncCallId"/> is null.
        /// </summary>
        public bool IsNull { get; }

        /// <summary>
        /// Gets a null instance of the <see cref="AsyncCallId"/> struct.
        /// </summary>
        public static AsyncCallId Null => default;

        /// <inheritdoc/>
        public bool Equals( AsyncCallId other )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override bool Equals( object obj )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
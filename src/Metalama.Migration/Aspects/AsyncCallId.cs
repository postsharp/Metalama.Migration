using System;

namespace PostSharp.Aspects
{
    public struct AsyncCallId : IEquatable<AsyncCallId>
    {
        public bool IsNull { get; }

        public static AsyncCallId Null => default;

        public bool Equals( AsyncCallId other )
        {
            throw new NotImplementedException();
        }

        public override bool Equals( object obj )
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( AsyncCallId left, AsyncCallId right )
        {
            return left.Equals( right );
        }

        public static bool operator !=( AsyncCallId left, AsyncCallId right )
        {
            return !left.Equals( right );
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
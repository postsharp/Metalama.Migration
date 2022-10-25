using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public struct DeclarationIdentifier : IEquatable<DeclarationIdentifier>
    {
        public DeclarationIdentifier( long value )
        {
            throw new NotImplementedException();
        }

        public const int MaxTypeIndex = 0;

        public const int MaxMemberIndex = 0;

        public static DeclarationIdentifier Null { get; }

        public bool IsNull { get; }

        public int MemberIndex { get; }

        public int TypeIndex { get; }

        public int AssemblyId { get; }

        public DeclarationIdentifier GetDeclaringTypeIdentifier()
        {
            throw new NotImplementedException();
        }

        public static DeclarationIdentifier GetDeclarationIdentifier( MemberInfo declaration )
        {
            throw new NotImplementedException();
        }

        public bool Equals( DeclarationIdentifier other )
        {
            throw new NotImplementedException();
        }

        public override bool Equals( object obj )
        {
            if (ReferenceEquals( null, obj ))
            {
                return false;
            }

            return obj is DeclarationIdentifier && Equals( (DeclarationIdentifier)obj );
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        public static bool operator ==( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            return left.Equals( right );
        }

        public static bool operator !=( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            return !left.Equals( right );
        }
    }
}
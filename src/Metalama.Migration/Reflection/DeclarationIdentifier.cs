using System;
using System.Diagnostics;
using System.Reflection;

namespace PostSharp.Reflection
{
    [Serializable]
    public struct DeclarationIdentifier : IEquatable<DeclarationIdentifier>
    {
        // For details about the risk of collisions, see http://en.wikipedia.org/wiki/Birthday_attack

        // Format:  AAAAAAATTTTKMMMM
        //          FEDCBA9876543210
        //   where: AAAAAAA:AssemblyId:  width = 32    32-64
        //          TTTT:   TypeIndex:     width = 16    16-31   --> CEIP data shows a max number of 12K types in an assembly
        //          MMMM :  MemberIndex:   width = 16    0-15
        //          Total: 

        [DebuggerStepThrough]

        // TODO: add next line in the .NET 4.5 profile only.
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
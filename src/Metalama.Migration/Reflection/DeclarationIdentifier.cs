using System;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    /// <summary>
    /// Encapsulates a unique identifier of a declaration. The identifier does not contain the kind of declaration. Different declarations of different kinds can have the same identifier.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The <see cref="DeclarationIdentifier"/> concept provides an efficient mechanism to correlate
    /// data that depend on the target declaration of the advice. Typically, such data can be computed at build time
    /// and serialized into the aspect, then consumed at run time. Without the <see cref="DeclarationIdentifier"/> concept,
    /// the data would be stored in a dictionary, for instance <c>Dictionary&lt;MethodInfo,MethodData&gt;</c> where <c>MethodData</c>
    /// is a custom class. However, relying on a dictionary has some performance costs. Thanks to the
    /// the <see cref="DeclarationIdentifier"/> concept, data can be stored in an array, because the <see cref="MemberIndex"/> 
    /// is guaranteed to be unique in a given type for a given kind of member (for instance, <see cref="MemberIndex"/> is unique for all methods in the same type).
    /// Array lookups are much faster than dictionary lookups and do not rely on reflection, which gives a significant performance benefit.
    /// </para>
    /// <note>
    /// <para>
    /// Although the CIL specification allows for up to 2^24 types in the same assembly and 2^24 methods (or other members) in the same type, the <see cref="DeclarationIdentifier"/>
    /// implementation assumes that there will be no more than 2^16 types in the same assembly and 2^16 members of the same kind in the same type. 
    /// The <see cref="AssemblyId"/> property to be coded on 32 bits. The <see cref="AssemblyId"/> is computed
    /// by running the MD5 algorithm on the full assembly name. The probability of hash collision is approximately 10^-6 for an application of 100 assemblies and 10^-5
    /// for an application of 1,000 assemblies. Collisions can be avoided by adding the <see cref="AssemblyIdAttribute"/> custom attribute to one of the assemblies causing
    /// a hash collision. Note that hash collisions are not automatically detected by PostSharp. However, you can build a hash collision detection program by looking at
    /// the <see cref="AssemblyIdAttribute"/> custom attribute on all assemblies of your application after PostSharp has been executed.
    /// </para>
    /// </note>
    /// </remarks>
    /// <see cref="AdviceArgs.DeclarationIdentifier"/>
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

        /// <exclude/>
        [DebuggerStepThrough]

        // TODO: add next line in the .NET 4.5 profile only.
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DeclarationIdentifier( long value )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Maximum number of types per assembly supported by the <see cref="DeclarationIdentifier"/> class.
        /// </summary>
        public const int MaxTypeIndex = 0;

        /// <summary>
        /// Maximum number of the same kind in the same type supported by the <see cref="DeclarationIdentifier"/> class.
        /// </summary>
        public const int MaxMemberIndex = 0;

        /// <summary>
        /// Gets a null instance of the <see cref="DeclarationIdentifier"/> type/
        /// </summary>
        /// <seealso cref="IsNull"/>
        public static DeclarationIdentifier Null { get; }

        /// <summary>
        /// Determines whether the current <see cref="DeclarationIdentifier"/> is null.
        /// </summary>
        public bool IsNull { get; }

        /// <summary>
        /// Gets a number that uniquely identifies the member inside its declaring type, for the given member kind. 
        /// </summary>
        /// <remarks>
        /// <para>The value of this property is guaranteed to be smaller than the total number of methods in the declaring type.</para>
        /// <para>The value is guaranteed to be unique only in the declaring type, not in the set of base types. Numbering of members restarts at 0 for every derived type.</para>
        /// </remarks>
        public int MemberIndex { get; }

        /// <summary>
        /// Gets a number that uniquely identifies the type inside its declaring assembly.
        /// </summary>
        public int TypeIndex { get; }

        /// <summary>
        /// Gets a 29-bit of the name of the assembly containing the declaration represented by the current <see cref="DeclarationIdentifier"/>.
        /// </summary>
        public int AssemblyId { get; }

        /// <summary>
        /// Gets the <see cref="DeclarationIdentifier"/> that represents the declaring type of the declaration represented by the current <see cref="DeclarationIdentifier"/>.
        /// </summary>
        /// <returns>The <see cref="DeclarationIdentifier"/> that represents the declaring type of the declaration represented by the current <see cref="DeclarationIdentifier"/>.
        /// If the current <see cref="DeclarationIdentifier"/> already represents a type, this method returns the current <see cref="DeclarationIdentifier"/>.
        /// </returns>
        public DeclarationIdentifier GetDeclaringTypeIdentifier()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the <see cref="DeclarationIdentifier"/> for a given declaration.
        /// </summary>
        /// <param name="declaration">A <see cref="Type"/>, <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="FieldInfo"/>, <see cref="EventInfo"/> or <see cref="PropertyInfo"/>.</param>
        /// <returns>A <see cref="DeclarationIdentifier"/> that identifies <paramref name="declaration"/>.</returns>
        public static DeclarationIdentifier GetDeclarationIdentifier( MemberInfo declaration )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool Equals( DeclarationIdentifier other )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            if (ReferenceEquals( null, obj ))
            {
                return false;
            }

            return obj is DeclarationIdentifier && Equals( (DeclarationIdentifier)obj );
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether two instances of the <see cref="DeclarationIdentifier"/> type are equal.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            return left.Equals( right );
        }

        /// <summary>
        /// Determines whether two instances of the <see cref="DeclarationIdentifier"/> type are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=( DeclarationIdentifier left, DeclarationIdentifier right )
        {
            return !left.Equals( right );
        }
    }
}
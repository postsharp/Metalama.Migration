namespace PostSharp.Reflection
{
    /// <summary>
    ///   Kinds of code references (<see cref = "ICodeReference" />).
    /// </summary>
    public enum CodeReferenceKind
    {
        /// <summary>
        ///   No code reference.
        /// </summary>
        None = 0,

        /// <summary>
        ///   Type inheritance. The base type is the <see cref = "ICodeReference.ReferencedDeclaration" />;
        ///   the child type is the <see cref = "ICodeReference.ReferencingDeclaration" />.
        ///   See <see cref = "TypeInheritanceCodeReference" />.
        /// </summary>
        TypeInheritance = 1,

        /// <summary>
        ///   Member type (field or property type, method return type, or parameter type).
        ///   The member type is the <see cref = "ICodeReference.ReferencedDeclaration" />.
        ///   See <see cref = "MemberTypeCodeReference" />.
        /// </summary>
        MemberType = 2,

        /// <summary>
        ///   Operand of an instruction in a method body. The <see cref = "ICodeReference.ReferencingDeclaration" />
        ///   is the method. See <see cref="MethodUsageCodeReference"/>.
        /// </summary>
        MethodUsage = 16
    }
}
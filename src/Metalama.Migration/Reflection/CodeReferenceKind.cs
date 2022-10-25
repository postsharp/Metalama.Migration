using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="ReferenceKinds"/>.
    /// </summary>
    public enum CodeReferenceKind
    {
        None = 0,

        TypeInheritance = 1,

        MemberType = 2,

        MethodUsage = 16
    }
}
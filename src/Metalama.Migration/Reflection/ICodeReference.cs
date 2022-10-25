using Metalama.Framework.Validation;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="DeclarationValidationContext"/> or <see cref="ReferenceValidationContext"/>. 
    /// </summary>
    public interface ICodeReference
    {
        object ReferencingDeclaration { get; }

        object ReferencedDeclaration { get; }

        CodeReferenceKind ReferenceKind { get; }
    }
}
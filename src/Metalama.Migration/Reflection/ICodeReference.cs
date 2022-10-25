namespace PostSharp.Reflection
{
    public interface ICodeReference
    {
        object ReferencingDeclaration { get; }

        object ReferencedDeclaration { get; }

        CodeReferenceKind ReferenceKind { get; }
    }
}
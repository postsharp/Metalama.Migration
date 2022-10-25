using Metalama.Framework.Code;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use the <see cref="IMember"/>.<see cref="INamedDeclaration.Name"/> property.
    /// </summary>
    public sealed class DeclarationNameAttribute : AdviceParameterAttribute
    {
        public bool IncludeTypeName { get; set; }
    }
}
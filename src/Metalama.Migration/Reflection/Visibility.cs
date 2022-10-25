using Metalama.Framework.Code;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="Accessibility"/>.
    /// </summary>
    public enum Visibility
    {
        Public,

        Family,

        Assembly,

        FamilyOrAssembly,

        FamilyAndAssembly,

        Private
    }
}
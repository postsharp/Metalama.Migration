using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use <see cref="meta"/>.<see cref="meta.This"/> in the template.
    /// </summary>
    public sealed class ThisAttribute : AdviceParameterAttribute { }
}
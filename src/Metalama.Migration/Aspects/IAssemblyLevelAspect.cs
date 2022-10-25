#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects applied at assembly level.
    /// </summary>
    /// <remarks>
    ///   An assembly-level aspect has no equivalent to <b>RuntimeInitialize</b> since assemblies are never initialized.
    /// </remarks>
    /// <seealso cref = "IAssemblyLevelAspectBuildSemantics" />
    /// <seealso cref = "AssemblyLevelAspect" />
    public interface IAssemblyLevelAspect : IAspect { }
}
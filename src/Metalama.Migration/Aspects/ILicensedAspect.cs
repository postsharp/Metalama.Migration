#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public interface ILicensedAspect
    {
        string GetLicenseRequirements();
    }
}
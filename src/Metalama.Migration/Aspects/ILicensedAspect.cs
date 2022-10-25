#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    public interface ILicensedAspect
    {
        string GetLicenseRequirements();
    }
}
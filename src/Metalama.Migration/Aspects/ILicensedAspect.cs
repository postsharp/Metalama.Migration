#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <exclude/>
    public interface ILicensedAspect
    {
        /// <exclude/>
        string GetLicenseRequirements();
    }
}
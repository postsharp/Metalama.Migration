// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


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
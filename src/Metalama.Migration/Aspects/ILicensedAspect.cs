﻿// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

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
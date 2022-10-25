// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Eligibility;
using System;

#pragma warning disable CA1008 // Enums should have zero value named None.

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, the valid targets are determined by the declaration types for which the <see cref="IAspect{T}"/> interface is implemented.
    /// Additionally, you can implement the <see cref="IEligible{T}.BuildEligibility"/> method.
    /// </summary>
    [Flags]
    public enum MulticastTargets
    {
        Default = 0,

        Class = 1,

        Struct = 2,

        Enum = 4,

        Delegate = 8,

        Interface = 16,

        AnyType = Class | Struct | Enum | Delegate | Interface,

        Field = 32,

        Method = 64,

        InstanceConstructor = 128,

        StaticConstructor = 256,

        Property = 512,

        Event = 1024,

        AnyMember = Field | Method | InstanceConstructor | StaticConstructor | Property | Event,

        Assembly = 2048,

        Parameter = 4096,

        ReturnValue = 8192,

        All = Assembly | AnyMember | AnyType | Parameter | ReturnValue
    }
}
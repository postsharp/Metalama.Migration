// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Code;
using PostSharp.Constraints;
using PostSharp.Extensibility;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="IAssemblyIdentity"/>.
    /// </summary>
    [InternalImplement]
    public interface IAssemblyName
    {
        string Name { get; }

        Version Version { get; }

        byte[] GetPublicKey();

        byte[] GetPublicKeyToken();

        string Culture { get; }

        bool IsStronglyNamed { get; }

        bool IsRetargetable { get; }

        AssemblyProcessorArchitecture ProcessorArchitecture { get; }

        BindingContext BindingContext { get; }
    }

    /// <summary>
    /// The processor architecture is not exposed in Metalama.
    /// </summary>
    public enum AssemblyProcessorArchitecture
    {
        None = 0x0000,

        MSIL = 0x0001,

        X86 = 0x0002,

        IA64 = 0x0003,

        Amd64 = 0x0004,

        Arm = 0x0005,

        NoPlatform = 0x0007
    }
}
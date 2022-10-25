using System;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
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
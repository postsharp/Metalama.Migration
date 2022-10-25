using System;
using PostSharp.Constraints;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Defines the semantics of an assembly name.
    /// </summary>
    [InternalImplement]
    public interface IAssemblyName
    {
        /// <summary>
        ///   Gets the assembly friendly name.
        /// </summary>
        /// <value>
        ///   The assembly friendly name.
        /// </value>
        string Name { get; }

        /// <summary>
        ///   Gets the assembly version.
        /// </summary>
        /// <value>
        ///   A <see cref = "Version" />.
        /// </value>
        Version Version { get; }

        /// <summary>
        ///   Gets the assembly public key.
        /// </summary>
        /// <value>
        ///   An array of bytes containing the public key,
        ///   or <c>null</c> if no public key is specified (for instance if
        ///   only the public key token is given).
        /// </value>
        /// <returns>An array of bytes containing the public key,
        ///   or <c>null</c> if no public key is specified.</returns>
        byte[] GetPublicKey();

        /// <summary>
        ///   Gets the assembly public key token.
        /// </summary>
        /// <returns>An array of bytes containing the public key token,
        ///   or <c>null</c> if no public key is specified.</returns>
        byte[] GetPublicKeyToken();

        /// <summary>
        ///   Gets the assembly culture name.
        /// </summary>
        /// <value>
        ///   The standard assembly culture name, or <c>null</c> if the assembly
        ///   is culture-neutral.
        /// </value>
        string Culture { get; }

        /// <summary>
        ///   Determines whether the current assembly (or assembly reference) contains a strong name signature.
        /// </summary>
        bool IsStronglyNamed { get; }

        /// <summary>
        /// Determines whether the reference is retargetable by the CLR, i.e. can be accommodated by
        /// an assembly whose identity does not match the current assembly reference.
        /// </summary>
        bool IsRetargetable { get; }

        /// <summary>
        ///   Gets the processor architecture that the current assembly targets.
        /// </summary>
        AssemblyProcessorArchitecture ProcessorArchitecture { get; }

        /// <summary>
        /// Gets the <see cref="BindingContext"/> in which the assembly name is valid.
        /// </summary>
        BindingContext BindingContext { get; }
    }

    /// <summary>
    /// Processor architectures of an assembly.
    /// </summary>
    public enum AssemblyProcessorArchitecture
    {
        /// <summary>
        /// None (or not set).
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// MSIL (platform-neutral).
        /// </summary>
        MSIL = 0x0001,

        /// <summary>
        /// 32-bit x86.
        /// </summary>
        X86 = 0x0002,

        /// <summary>
        /// Itanium 64-bit
        /// </summary>
        IA64 = 0x0003,

        /// <summary>
        /// 64-bit x86
        /// </summary>
        Amd64 = 0x0004,

        /// <summary>
        /// ARM.
        /// </summary>
        Arm = 0x0005,

        /// <summary>
        /// Reference assembly only (the assembly cannot be executed at run time).
        /// </summary>
        NoPlatform = 0x0007
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Extensibility
{
    /// <summary>
    /// Enumeration of contexts in which assemblies can be loaded.
    /// </summary>
    public enum BindingContext
    {
        /// <summary>
        /// Unspecified.
        /// </summary>
        None,

        /// <summary>
        /// Reference assemblies the ones the project is being linked against. They are typically located
        /// in directory <c>C:\Program Files\Reference Assemblies</c> for the proper target platform.
        /// </summary>
        Reference,

        /// <summary>
        /// Runtime assemblies are the ones loaded at build time in the CLR. They are typically located
        /// in GAC.
        /// </summary>
        Runtime
    }
}

// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Kind of inheritance of <see cref = "MulticastAttribute" />.
    /// </summary>
    public enum MulticastInheritance
    {
        /// <summary>
        ///   No inheritance.
        /// </summary>
        None,

        /// <summary>
        ///   The instance is inherited to children of the original element,
        ///   but multicasting is not applied to members of children.
        /// </summary>
        /// <remarks>
        ///   See https://doc.postsharp.net/multicast-inheritance.
        /// </remarks>
        Strict,

        /// <summary>
        ///   The instance is inherited to children of the original element
        ///   and multicasting is applied to members of children.
        /// </summary>
        /// <remarks>
        ///   See https://doc.postsharp.net/multicast-inheritance.
        /// </remarks>
        Multicast
    }
}

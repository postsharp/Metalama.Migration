// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Visibility of types and type members.
    /// </summary>
    public enum Visibility
    {
        /// <summary>
        ///   Public.
        /// </summary>
        Public,

        /// <summary>
        ///   Family (protected).
        /// </summary>
        Family,

        /// <summary>
        ///   Assembly (internal).
        /// </summary>
        Assembly,

        /// <summary>
        ///   Family or assembly (protected internal).
        /// </summary>
        FamilyOrAssembly,

        /// <summary>
        ///   Family and assembly (no C# equivalent: protected types inside the current assembly).
        /// </summary>
        FamilyAndAssembly,

        /// <summary>
        ///   Private.
        /// </summary>
        Private,
    }
}
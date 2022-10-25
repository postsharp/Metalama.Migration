// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Exposes the PostSharp version with which the current version of PostSharp should be backward compatible.
    /// </summary>
    public interface ICompatibilityLevelService : IService
    {
        /// <summary>
        /// Gets the PostSharp version with which the current version of PostSharp should be backward compatible.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Some breaking changes may ignore this property.
        /// </para>
        /// </remarks>
        Version CompatibilityLevel { get; }
    }
}
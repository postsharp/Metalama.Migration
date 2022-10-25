// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Constraints;
using System;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Represents a file of source code.
    /// </summary>
    [InternalImplement]
    public interface ISourceDocument
    {
        /// <summary>
        ///   Full path of the file.
        /// </summary>
        string FileName { get; }

        /// <summary>
        ///   Language (<see cref = "Guid" /> according to Microsoft PDB specification).
        /// </summary>
        /// <remarks>
        /// <para>The language GUID varies according to the kind of PDB file (native or portable).</para>
        /// </remarks>
        Guid Language { get; }
    }
}
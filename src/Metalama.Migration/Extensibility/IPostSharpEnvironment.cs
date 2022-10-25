// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides information about the current <c>PostSharp</c> environment.
    /// </summary>
    
    public interface IPostSharpEnvironment
    {
        /// <summary>
        ///   Gets the currently executing project.
        /// </summary>
        /// <value>
        ///   The current project, or <c>null</c> if there is no current project.
        /// </value>
        IProject CurrentProject { get; }

        /// <summary>
        ///   Loads an <see cref = "Assembly" /> given its file name.
        /// </summary>
        /// <param name = "fileName">Full assembly path.</param>
        /// <returns>The <see cref = "Assembly" />.</returns>
        /// <remarks>
        ///   <para>
        ///     Use this method instead of <see cref = "Assembly.LoadFile(string)" />.
        ///   </para>
        ///   <note>
        ///     You cannot load two assemblies with a different path and the same identity (strong name) into PostSharp.
        ///   </note>
        /// </remarks>
        Assembly LoadAssemblyFromFile( string fileName );

    }
}

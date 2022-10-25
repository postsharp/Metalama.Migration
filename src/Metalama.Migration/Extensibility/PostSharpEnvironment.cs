// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Reflection;
using System.Threading;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides access to the current <c>PostSharp</c> environment (<see cref = "IPostSharpEnvironment" />).
    /// </summary>
    
    public static class PostSharpEnvironment
    {
        private static IPostSharpEnvironment currentEnvironment;

        /// <summary>
        ///   Gets the current <c>PostSharp</c> environment, or <c>null</c>
        ///   if the <c>PostSharp</c> Platform is not loaded in the current
        ///   context.
        /// </summary>
        public static IPostSharpEnvironment Current
        {
            get { return currentEnvironment; }
            internal set { currentEnvironment = value; }
        }

        /// <summary>
        /// Gets the current PostSharp project.
        /// </summary>
        public static IProject CurrentProject
        {
            get { return currentEnvironment == null ? null : currentEnvironment.CurrentProject; }
        }

        /// <summary>
        ///   Determines whether the <c>PostSharp</c> Platform is currently loaded.
        /// </summary>
        public static bool IsPostSharpRunning
        {
            get { return currentEnvironment != null; }
        }
    }
}


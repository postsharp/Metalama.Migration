// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Build-time semantics of aspects applied at assembly level.
    /// </summary>
    /// <seealso cref = "AssemblyLevelAspect" />
    
    public interface IAssemblyLevelAspectBuildSemantics : IAspect
    {
        /// <summary>
        ///   Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked
        ///   before any other build-time method.
        /// </summary>
        /// <param name = "assembly">Assembly to which the current aspect is applied</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        /// <param name = "aspectInfo">Reserved for future usage.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo );
    }
}

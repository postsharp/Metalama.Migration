// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of aspects applied to methods.
    /// </summary>
    /// <seealso cref = "IMethodLevelAspectBuildSemantics" />
    /// <seealso cref = "MethodLevelAspect" />
    public interface IMethodLevelAspect : IAspect
    {
        /// <summary>
        ///   Initializes the current aspect.
        /// </summary>
        /// <param name = "method">Method to which the current aspect is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( MethodBase method );
    }


}
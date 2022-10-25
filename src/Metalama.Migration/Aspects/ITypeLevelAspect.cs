// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Run-time semantics of aspects applied to types.
    /// </summary>
    /// <seealso cref = "ITypeLevelAspectBuildSemantics" />
    public interface ITypeLevelAspect : IAspect
    {
        /// <summary>
        ///   Initializes the current aspect.
        /// </summary>
        /// <param name = "type">Type to which the current aspect is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( Type type );
    }

}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Run-time semantics of aspects applied to fields.
    /// </summary>
    /// <seealso cref = "IFieldLevelAspectBuildSemantics" />
    /// <seealso cref = "FieldLevelAspect" />
    public interface IFieldLevelAspect : IAspect
    {
        /// <summary>
        ///   Method invoked at runtime before any other method of the aspect is invoked.
        /// </summary>
        /// <param name = "field">Field on which this instance is applied.</param>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoInitializingAspects']/*" />
        void RuntimeInitialize( FieldInfo field );
    }


}
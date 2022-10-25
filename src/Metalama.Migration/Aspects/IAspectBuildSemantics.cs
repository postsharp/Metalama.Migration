// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Compile-time semantics of <see cref = "IAspect" />.
    /// </summary>
    [SuppressAnnotationValidation]
    public interface IAspectBuildSemantics : IValidableAnnotation
    {
        /// <summary>
        ///   Method invoked at build time to get the imperative configuration of the current <see cref = "Aspect" />.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current aspect has been applied.
        /// </param>
        /// <returns>An <see cref = "AspectConfiguration" /> representing the imperative configuration
        ///   of the current <see cref = "Aspect" />.</returns>
        AspectConfiguration GetAspectConfiguration( object targetElement );
    }
}

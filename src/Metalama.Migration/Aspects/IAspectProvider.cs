// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Extensibility;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Interface that, when implemented by an aspect class, allows aspect instances
    ///   to provide other aspects to the weaver.
    /// </summary>
    public interface IAspectProvider : IAspect, IService
    {
        /// <summary>
        ///   Provides new aspects.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current aspect has been applied.
        /// </param>
        /// <returns>A set of aspect instances.</returns>
        /// <remarks>
        ///   <para>Implementations of this method are only allowed to return aspect instances applied on elements
        ///     of code located <i>under</i> the target element of code (<paramref name = "targetElement" />).
        ///     For instance, a type-level <see cref = "IAspectProvider" /> can provide aspects on methods of the current type,
        ///     but not of other types.</para>
        /// </remarks>
        IEnumerable<AspectInstance> ProvideAspects( object targetElement );
    }

}
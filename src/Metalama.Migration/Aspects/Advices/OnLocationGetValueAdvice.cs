// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Internals;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method of an aspect class, specifies
    ///   that this method is an advice having the same semantics as <see cref = "ILocationInterceptionAspect.OnGetValue" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "ILocationInterceptionAspect.OnGetValue" />. However, it can be static.
    ///   </para>
    ///   <para>
    ///     If an aspect defines many advices (among <see cref = "OnLocationSetValueAdvice" />, 
    ///     <see cref = "OnLocationGetValueAdvice" />) and if these advices
    ///     are meant to be applied to the same properties with consistent ordering, they should be
    ///     grouped together (see <see cref = "GroupingAdvice.Master" /> property).
    ///   </para>
    ///   <para>
    ///     Standalone advices or group masters should also be annotated by a custom attribute derived from
    ///     <see cref = "Pointcut" />.
    ///   </para>
    /// </remarks>
    /// <seealso cref = "LocationLevelAspect" />
    /// <seealso cref = "OnLocationSetValueAdvice" />
    /// <seealso cref = "OnInstanceLocationInitializedAdvice" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    [RequiresLocationInterceptionAdviceAnalysis]
    [RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget)]
    public sealed class OnLocationGetValueAdvice : GroupingAdvice
    {
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Dependencies;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Base class for all advices that are possibly composed of
    ///   multiple advices that can be grouped together using the <see cref = "Master" />
    ///   property.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public abstract class GroupingAdvice : Advice
    {
        /// <summary>
        ///   Name of the master advice method. If this property is not set,
        ///   the current method is itself the master of the group. Only
        ///   master methods can define selectors (<see cref = "Pointcut" />)
        ///   and dependencies (<see cref = "AspectDependencyAttribute" />).
        /// </summary>
        public string Master { get; set; }
    }
}
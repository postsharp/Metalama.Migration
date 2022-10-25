// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Internals;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Custom attribute that, when applied to a method of an aspect class, specifies that this method
    /// should be invoked whenever the aspect instance needs to be initialized. The target method
    /// must have a <c>void</c> return value and have a single parameter of type <see cref="AspectInitializationReason"/>.
    /// This method is equivalent to <see cref="IInstanceScopedAspect.RuntimeInitializeInstance"/>
    /// </summary>
    /// <remarks>
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.StepOut)]
    public sealed class InitializeAspectInstanceAdvice : Advice
    {
        
    }
}

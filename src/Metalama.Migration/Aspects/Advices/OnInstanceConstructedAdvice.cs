// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Internals;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Custom attribute that, when applied to a method of an aspect, specifies that this method should be executed 
    /// after the last instance constructor of the target class of the aspect has completed execution. That is, this method will be invoked when the target object
    /// will be fully constructed. This custom attribute can be applied only on methods that have return type <c>void</c> and no parameters.
    /// </summary>
    /// <remarks>
    /// The target object is fully constructed when all its constructors complete execution, including constructors of subclasses. For example, if you apply
    /// this advice to type <c>A</c>, and class <c>B</c> extends class <c>A</c>, then if you create a new instance of <c>B</c>, the method will be invoked only
    /// after B's constructor ends.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.StepOut)]
    public sealed class OnInstanceConstructedAdvice : Advice
    {
        
    }
}

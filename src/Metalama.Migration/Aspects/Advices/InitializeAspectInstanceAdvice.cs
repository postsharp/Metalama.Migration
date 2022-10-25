using System;

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
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = false, Inherited = false )]
    public sealed class InitializeAspectInstanceAdvice : Advice { }
}
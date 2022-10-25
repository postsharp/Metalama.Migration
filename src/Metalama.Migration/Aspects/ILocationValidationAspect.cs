// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using PostSharp.Reflection;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    /// Ancestor of <see cref="ILocationValidationAspect{T}"/>.
    /// </summary>
    /// <remarks>
    /// <para>This interface exists only because PostSharp SDK requires a common non-generic interface for <see cref="ILocationValidationAspect{T}"/>.
    /// It should not be used in user code.</para>
    /// </remarks>
    public interface ILocationValidationAspect : IAspect
    {
    }

    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on a location (field, property, or parameter), 
    ///   validates the value assigned to this location using method <see cref="ValidateValue"/>, and throws
    ///   the exception returned by this method if any.
    /// </summary>
    /// <typeparam name="T">Type of values validated by the current aspect.</typeparam>
    /// <remarks>
    ///   <para>An aspect will typically implement several generic instances of the current interface,
    ///    with different values of <typeparamref name="T"/>. The aspect can be applied only to locations
    ///    for which there is an exact type match. PostSharp does not implement any type conversion, even
    ///    when this conversion is implicitly supported by the compiler, for instance <c>int</c> to <c>long</c>.
    ///    Therefore, if your aspect must be able to validate all integers, you may need to implement
    ///    the interface instances for <typeparamref name="T"/> ranging in <c>long</c>, <c>int</c>, <c>short</c>,
    ///     <c>sbyte</c> and possibly their unsigned variant. However, values of a derived type can be
    ///     validated if <typeparamref name="T"/> is the base type.
    /// </para>
    /// </remarks>
    /// <seealso cref="LocationValidationAdvice"/>
    [HasInheritedAttribute]
    public interface ILocationValidationAspect<T> : ILocationValidationAspect
    {
        /// <summary>
        /// Validates the value being assigned to the location to which the current aspect has been applied.
        /// </summary>
        /// <param name="value">Value being applied to the location.</param>
        /// <param name="locationName">Name of the location.</param>
        /// <param name="locationKind">Location kind (<see cref="LocationKind.Field"/>, <see cref="LocationKind.Property"/>, or
        /// <see cref="LocationKind.Parameter"/>).
        /// </param>
        /// <param name="context">Indicates the context in which the value is being validated, such as precondition or postcondition for ref method parameters.</param>
        /// <returns>The <see cref="Exception"/> to be thrown, or <c>null</c> if no exception needs to be thrown.</returns>
        [RequiresDebuggerEnhancement( DebuggerStepOverAspectBehavior.StepOut ), HasInheritedAttribute]
        Exception ValidateValue( T value, string locationName, LocationKind locationKind, LocationValidationContext context );
    }
}

using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Custom attribute that, when applied on a method of an aspect class, specifies that this method
    /// has the same semantic as the <see cref="ILocationValidationAspect{T}.ValidateValue"/> method
    /// of the <see cref="ILocationValidationAspect{T}"/> interface.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "ILocationValidationAspect{T}.ValidateValue" />, where <c>T</c> can be any type. However, the method can be static.
    ///   </para>
    /// </remarks>
    /// <seealso cref="ILocationValidationAspect{T}"/>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public class LocationValidationAdvice : GroupingAdvice
    {
        /// <summary>
        /// Determines a priority for selecting a validation method from a group when more than one method matches the target element type.
        /// A method with a lower value has priority over a method with a higher value.
        /// </summary>
        public int Priority { get; set; } = int.MaxValue;
    }
}
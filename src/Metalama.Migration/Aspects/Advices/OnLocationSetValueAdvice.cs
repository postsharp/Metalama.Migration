using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    ///   Custom attribute that, when applied on a method of an aspect class, specifies
    ///   that this method is an advice having the same semantics as <see cref = "ILocationInterceptionAspect.OnSetValue" />.
    /// </summary>
    /// <remarks>
    ///   <para>
    ///     The method to which this custom attribute is applied must be public and must have the same signature as
    ///     <see cref = "ILocationInterceptionAspect.OnSetValue" />. However, it can be static.
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
    /// <seealso cref = "OnLocationGetValueAdvice" />
    /// <seealso cref = "OnInstanceLocationInitializedAdvice" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoAddBehaviorsToMembers']/*" />
    [AttributeUsage( AttributeTargets.Method, AllowMultiple = true, Inherited = true )]
    public sealed class OnLocationSetValueAdvice : GroupingAdvice { }
}
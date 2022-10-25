using System;

namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

// TODO: Rename all types to respect the convention.

    /// <summary>
    ///   Base class for all custom attributes representing an advice.
    /// </summary>
    /// <remarks>
    ///   <para>Advices are behaviors added to aspects by the way of custom
    ///     attributes. Other ways to add behaviors is to implement interface methods.
    ///   </para>
    ///   <para>
    ///     Advice custom attributes are typically used on aspect classes,
    ///     or on members of aspect classes.
    ///   </para>
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoComplexAspects']/*" />
    public abstract class Advice : Attribute
    {
        /// <summary>
        /// A human-readable description of the current advice.
        /// </summary>
        /// <remarks>
        /// Set this property only on the master advice of the advice group.
        /// </remarks>
        public string Description { get; set; }

        /// <summary>
        /// Reduction in the code lines count achieved by applying the advice instance to one code element.
        /// </summary>
        public int LinesOfCodeAvoided { get; set; }
    }
}
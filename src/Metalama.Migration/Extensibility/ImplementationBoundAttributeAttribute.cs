// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects;

namespace PostSharp.Extensibility
{
    // TODO: redesign ImplementationBoundAttributeAttribute stuff.

    /// <summary>
    ///   Custom attribute meaning that custom attributes of a given type are
    ///   bound to the implementation, not to the semantics.
    /// </summary>
    /// <remarks>
    ///   <para>This custom attribute influences whether instances of a given other
    ///     custom attribute should be moved from the semantic to the implementation,
    ///     when the semantic is detached from the implementation.
    ///   </para>
    ///   <para>The <see cref="ImplementationBoundAttributeAttribute"/> is currently only honored 
    ///     when you apply an interception aspect  (<see cref="LocationInterceptionAspect"/>) to a field.
    ///     In this case, PostSharp creates a property from the field. The property becomes the semantic
    ///     and the field, made private, becomes the implementation.   Most custom attributes apply to semantics,
    ///     so they are moved from the field  the property. If a custom attribute must not be moved, it should be
    ///     marked with the <see cref = "ImplementationBoundAttributeAttribute" />
    ///     custom attribute.
    ///   </para>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class ImplementationBoundAttributeAttribute : Attribute
    {
        private readonly Type attributeType;

        /// <summary>
        ///   Initializes the new <see cref = "ImplementationBoundAttributeAttribute" />.
        /// </summary>
        /// <param name = "attributeType">Type of the custom attribute that
        ///   should not be moved from implementation to semantic.</param>
        public ImplementationBoundAttributeAttribute( Type attributeType )
        {
            this.attributeType = attributeType;
        }

        /// <summary>
        ///   Gets the type of the custom attribute that
        ///   should not be moved from implementation to semantic.
        /// </summary>
        public Type AttributeType
        {
            get { return this.attributeType; }
        }
    }
}
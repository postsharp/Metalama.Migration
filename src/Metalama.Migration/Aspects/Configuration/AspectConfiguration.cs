// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Dependencies;
using PostSharp.Aspects.Serialization;

#pragma warning disable CA2227 // Collection properties should be read only


namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of an <see cref = "IAspect" />.
    /// </summary>
    /// <remarks>
    ///   Every concrete aspect class has a corresponding configuration class derived from <see cref = "AspectConfiguration" />.
    /// </remarks>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public class AspectConfiguration
    {
        /// <summary>
        ///   Gets or sets the aspect priority. Aspects with smaller priority are processed first. The default priority is zero.
        /// </summary>
        /// <remarks>
        ///   Whenever possible, use dependencies (<see cref = "Dependencies" /> collection) to specify the ordering of aspects.
        ///   Unlike priorities, dependencies scale up in complexity, which can be important in larger projects.
        /// </remarks>
        public int? AspectPriority { get; set; }

        /// <summary>
        ///   Gets or sets the type of the serializer that will be used
        ///   to configure the current aspect.
        /// </summary>
        /// <remarks>
        ///   The type assigned to this property must derive from the <see cref = "AspectSerializer" /> class
        ///   and have a default constructor. Use <see cref="MsilAspectSerializer"/> to specify that the aspect will not
        ///   be serialized, but will be constructed using MSIL instructions.
        /// </remarks>
        public TypeIdentity SerializerType { get; set; }

        /// <summary>
        ///   Gets or sets the collection of dependencies.
        /// </summary>
        public AspectDependencyAttributeCollection Dependencies { get; set; }

        /// <summary>
        /// Specifies the action to take when the aspect is applied to an unsupported target element.
        /// </summary>
        public UnsupportedTargetAction? UnsupportedTargetAction { get; set; }
    }
}
// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects.Serialization;
using PostSharp.Extensibility;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configures an aspect of type <see cref = "IAspect" />.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    [AttributeUsage( AttributeTargets.Class )]
    public class AspectConfigurationAttribute : Attribute
    {
        private int? aspectPriority;

        /// <summary>
        ///   Gets or sets the weaving priority of the aspect.
        /// </summary>
        /// <value>The aspect priority, or <c>null</c> if the aspect priority is not specified.</value>
        /// <remarks>
        ///   <para>Advices with lower priority are executed before in case of 'entry' semantics (entering or invoking a
        ///     method, setting a field value), but this order is inverted for advices of 'exit' semantics (leaving a
        ///     method, getting a field value).
        ///   </para>
        ///   <para>This property must not be confused with <see cref = "MulticastAttribute.AttributePriority" />, which
        ///     solely influences the multicasting process.</para>
        /// </remarks>
        public int AspectPriority
        {
            get { return this.aspectPriority ?? 0; }
            set { this.aspectPriority = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref = "Type" /> of the serializer that will be used
        ///   to configure the current aspect.
        /// </summary>
        /// <remarks>
        ///   <para>The type assigned to this property must derive from the <see cref = "AspectSerializer" /> class
        ///     and have a default constructor. Use <see cref="MsilAspectSerializer"/> to specify that the aspect will not
        ///     be serialized, but will be constructed using MSIL instructions.
        ///   </para>
        ///   <para></para>
        /// </remarks>
        public Type SerializerType { get; set; }

        /// <summary>
        ///   Creates a concrete <see cref = "AspectConfiguration" /> instance specifically for the current 
        ///   <see cref = "AspectConfigurationAttribute" /> type.
        /// </summary>
        /// <returns>A new and empty instance of <see cref = "AspectConfiguration" />, whose concrete type corresponds to
        ///   the concrete type of the <see cref = "AspectConfigurationAttribute" />.</returns>
        /// <remarks>
        ///   This method should not set up the returned <see cref = "AspectConfiguration" />. After the current method has
        ///   returned, the <see cref = "SetAspectConfiguration" /> method will be invoked, and this method is responsible
        ///   for setting up the <see cref = "AspectConfiguration" />object.
        /// </remarks>
        protected virtual AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }


        /// <summary>
        ///   Gets the <see cref = "AspectConfiguration" /> corresponding to the current custom attribute.
        /// </summary>
        /// <returns>An <see cref = "AspectConfiguration" /> corresponding to the current custom attribute.</returns>
        /// <remarks>
        ///   <para>This method can be customized by overriding <see cref = "CreateAspectConfiguration" /> and/or
        ///     <see cref = "SetAspectConfiguration" /></para>.
        /// </remarks>
        public AspectConfiguration GetAspectConfiguration()
        {
            AspectConfiguration aspectConfiguration = this.CreateAspectConfiguration();
            this.SetAspectConfiguration( aspectConfiguration );
            return aspectConfiguration;
        }


        /// <summary>
        ///   Sets up an <see cref = "AspectConfiguration" /> object according to the current  custom attribute instance.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "CreateAspectConfiguration" /> method.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration )
        {
            aspectConfiguration.AspectPriority = this.aspectPriority;
            aspectConfiguration.SerializerType = TypeIdentity.FromType( this.SerializerType );
        }
    }
}
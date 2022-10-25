// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Eligibility;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using System;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="FieldOrPropertyAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Field | MulticastTargets.Property | MulticastTargets.Parameter | MulticastTargets.ReturnValue,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Parameter |
        AttributeTargets.ReturnValue,
        AllowMultiple = true )]
    public abstract class LocationLevelAspect : Aspect, ILocationLevelAspect, ILocationLevelAspectBuildSemantics
    {
        /// <inheritdoc/>
        public virtual void RuntimeInitialize( LocationInfo locationInfo ) { }

        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        public virtual void CompileTimeInitialize( LocationInfo targetLocation, AspectInfo aspectInfo ) { }

        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( LocationInfo locationInfo )
        {
            return true;
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            LocationInfo targetLocation ) { }

        /// <inheritdoc/>
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            this.SetAspectConfiguration( aspectConfiguration, (LocationInfo) targetElement );
        }

        /// <inheritdoc/>
        public sealed override bool CompileTimeValidate( object target )
        {
            return this.CompileTimeValidate( (LocationInfo) target );
        }
    }
}
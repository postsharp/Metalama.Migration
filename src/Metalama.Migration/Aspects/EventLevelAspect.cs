// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Eligibility;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="EventAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Event,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Event,
        AllowMultiple = true,
        Inherited = false )]
    public abstract class EventLevelAspect : Aspect, IEventLevelAspect, IEventLevelAspectBuildSemantics
    {
        /// <inheritdoc/>
        public virtual void RuntimeInitialize( EventInfo eventInfo ) { }

        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        public virtual void CompileTimeInitialize( EventInfo targetEvent, AspectInfo aspectInfo ) { }

        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( EventInfo targetEvent )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, EventInfo targetEvent ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public sealed override bool CompileTimeValidate( object target )
        {
            throw new NotImplementedException();
        }
    }
}
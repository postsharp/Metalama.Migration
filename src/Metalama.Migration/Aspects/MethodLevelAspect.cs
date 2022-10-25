// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using Metalama.Framework.Aspects;
using Metalama.Framework.Code;
using Metalama.Framework.Eligibility;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using System;
using System.Globalization;
using System.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="IAspect{T}"/> where <c>T</c> is <see cref="IMethod"/>.
    /// </summary>
    [MulticastAttributeUsage( MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.StaticConstructor )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Constructor,
        AllowMultiple = true )]
    public abstract class MethodLevelAspect : Aspect, IMethodLevelAspect, IMethodLevelAspectBuildSemantics
    {
        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( MethodBase method )
        {
            return true;
        }

        /// <inheritdoc/>
        public sealed override bool CompileTimeValidate( object target )
        {
            var method = target as MethodBase;

            if ( method == null )
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Aspects of type {0} can be applied to methods only.",
                        this.GetType().FullName ) );
            }

            return this.CompileTimeValidate( method );
        }

        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        public virtual void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo ) { }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod ) { }

        /// <inheritdoc/>
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            this.SetAspectConfiguration( aspectConfiguration, (MethodBase) targetElement );
        }

        /// <inheritdoc/>
        public virtual void RuntimeInitialize( MethodBase method ) { }
    }
}
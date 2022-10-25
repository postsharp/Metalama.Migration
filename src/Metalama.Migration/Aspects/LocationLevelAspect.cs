// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for aspects defined in fields, properties, or parameters.
    /// </summary>
    /// <remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <seealso cref="ILocationLevelAspect"/>
#if SERIALIZABLE
    [Serializable]
#endif
    [MulticastAttributeUsage(
        MulticastTargets.Field | MulticastTargets.Property | MulticastTargets.Parameter | MulticastTargets.ReturnValue,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Parameter |
        AttributeTargets.ReturnValue, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer(null)]
    public abstract class LocationLevelAspect : Aspect, ILocationLevelAspect, ILocationLevelAspectBuildSemantics
    {
        /// <inheritdoc />
        [RuntimeInitializeOptimization( RuntimeInitializeOptimizations.Ignore )]
        public virtual void RuntimeInitialize( LocationInfo locationInfo )
        {
        }

        /// <inheritdoc />
        public virtual void CompileTimeInitialize( LocationInfo targetLocation, AspectInfo aspectInfo )
        {
        }


        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "locationInfo">Location to which the aspect has been applied</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable field, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( LocationInfo locationInfo )
        {
            return true;
        }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "Aspect.CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetLocation">Location to which the current aspect has been applied.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration,
                                                       LocationInfo targetLocation )
        {
        }

        /// <inheritdoc />
        protected sealed override void SetAspectConfiguration( AspectConfiguration aspectConfiguration,
                                                               object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            this.SetAspectConfiguration( aspectConfiguration, (LocationInfo) targetElement );
        }

        /// <inheritdoc />
        public sealed override bool CompileTimeValidate( object target )
        {
            return this.CompileTimeValidate( (LocationInfo) target );
        }

    }
}
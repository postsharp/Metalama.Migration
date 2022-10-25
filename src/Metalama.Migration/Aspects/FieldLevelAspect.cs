// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for all aspects applied on fields.
    /// </summary>
    /// <seealso cref="IFieldLevelAspect"/>
    /// <remarks>
    /// <note>
    ///     Consider deriving your aspects from <see cref="LocationLevelAspect"/>; locations can abstract both fields and properties,
    /// making it possible to apply the same aspect to both.
    /// </note>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <seealso cref="LocationLevelAspect"/>
#if SERIALIZABLE
    [Serializable]
#endif
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer(null)]
    public abstract class FieldLevelAspect : Aspect, IFieldLevelAspect, IFieldLevelAspectBuildSemantics
    {


        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "field">Field to which the aspect has been applied</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable field, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( FieldInfo field )
        {
            return true;
        }

        /// <inheritdoc />
        public sealed override bool CompileTimeValidate( object target )
        {
            FieldInfo field = target as FieldInfo;
            if ( field == null )
                throw new ArgumentException( string.Format(CultureInfo.InvariantCulture, "Aspects of type {0} can be applied to fields only.",
                                                            this.GetType().FullName ) );

            return this.CompileTimeValidate( field );
        }

        /// <inheritdoc />
        public virtual void CompileTimeInitialize( FieldInfo field, AspectInfo aspectInfo )
        {
        }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "Aspect.CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetField">Field to which the current aspect has been applied.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the 
        ///     <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, FieldInfo targetField )
        {
        }

        /// <inheritdoc />
        protected sealed override void SetAspectConfiguration( AspectConfiguration aspectConfiguration,
                                                               object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            this.SetAspectConfiguration( aspectConfiguration, (FieldInfo) targetElement );
        }

        /// <inheritdoc />
        [RuntimeInitializeOptimization( RuntimeInitializeOptimizations.Ignore )]
        public virtual void RuntimeInitialize( FieldInfo field )
        {
        }
    }
}
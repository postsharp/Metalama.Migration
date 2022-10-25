// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using PostSharp.Aspects.Advices;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Serialization;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for all aspects that are declared using multicast custom attributes (<see cref="MulticastAttribute"/>).
    /// </summary>
    /// <remarks>
    /// <para>This class is not specific to any kind of declaration (method, field, type, ...). 
    ///  Considering deriving your aspect from <see cref="TypeLevelAspect"/>, <see cref="MethodLevelAspect"/>, <see cref="LocationLevelAspect"/>,
    /// or <see cref="EventLevelAspect"/> if it should be applied to a specific kind of declarations.
    /// </para>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>

#if SERIALIZABLE
    [Serializable]
#endif
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(AspectConfigurationAttribute) )]
    [Serializer(null)]
    public abstract class Aspect : MulticastAttribute, IAspect, IAspectBuildSemantics
    {
#if SERIALIZABLE
        [NonSerialized]
#endif
        [PNonSerialized]
        private int? aspectPriority;


        /// <summary>
        ///   Gets or sets the weaving priority of the aspect.
        /// </summary>
        /// <value>The aspect priority, or <c>0</c> if the aspect priority is
        ///   not specified.</value>
        /// <remarks>
        ///   <para>Advices with lower priority are executed before in case of
        ///     'entry' semantics (entering or invoking a method, setting a field
        ///     value), but this order is inverted for advices of 'exit' semantics
        ///     (leaving a method, getting a field value).
        ///   </para>
        ///   <para>This property must not be confused with 
        ///     <see cref = "MulticastAttribute.AttributePriority" />, which solely
        ///     influences the multicasting process.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectDependencies']/*" />
        public int AspectPriority
        {
            get { return this.aspectPriority ?? 0; }
            set { this.aspectPriority = value; }
        }

#if SERIALIZABLE
        [NonSerialized] 
#endif
        [PNonSerialized]
        private Type serializerType;


        /// <summary>
        ///   Gets or sets the <see cref = "Type" /> of the serializer (a type derived
        ///   from <see cref = "AspectSerializer" />) used to serialize the aspect instance
        ///   at build time and deserialize it at runtime.
        /// </summary>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoAspectSerialization']/*" />
        protected Type SerializerType
        {
            get { return this.serializerType; }
            set { this.serializerType = value; }
        }

        [PNonSerialized]
#if SERIALIZABLE
        [NonSerialized]
#endif
        private UnsupportedTargetAction? unsupportedTargetAction;

        /// <summary>
        /// Specifies the action to take when the aspect is applied to an unsupported target element.  This property affects only simple aspects, not composite aspects. 
        /// </summary>
        /// <remarks>
        /// This property only affects the built-in advices of the simple aspect classes, not advices of composite aspects. See <see href="custom-aspects.htm" target="_self">the conceptual documentation</see> for details.  For composite aspects, use the <c>UnsupportedTargetAction</c> property of the advice custom attribute, e.g. <see cref="OnMethodBoundaryAdvice.UnsupportedTargetAction"/>.
        /// </remarks>
        public UnsupportedTargetAction UnsupportedTargetAction
        {
            get { return this.unsupportedTargetAction.GetValueOrDefault( UnsupportedTargetAction.Default ); }
            set { this.unsupportedTargetAction = value; }
        }

        /// <inheritdoc />
        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            return this.CompileTimeValidate( target );
        }

        /// <summary>
        ///   Method invoked at build time to create a concrete <see cref = "AspectConfiguration" /> instance specifically
        ///   for the current <see cref = "Aspect" /> type.
        /// </summary>
        /// <returns>A new and empty instance of <see cref = "AspectConfiguration" />, whose concrete type corresponds to
        ///   the concrete type of the <see cref = "Aspect" />.</returns>
        /// <remarks>
        ///   This method should not set up the returned <see cref = "AspectConfiguration" />. After the current method has
        ///   returned, the <see cref = "SetAspectConfiguration" /> method will be invoked, and this method is responsible
        ///   for setting up the <see cref = "AspectConfiguration" />object.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "Aspect" />
        ///   has been applied.
        /// </param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the 
        ///     <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, object targetElement )
        {
            aspectConfiguration.AspectPriority = this.aspectPriority;
            aspectConfiguration.SerializerType = TypeIdentity.FromType( this.serializerType );
            
            if ( this.unsupportedTargetAction.HasValue )
            {
                aspectConfiguration.UnsupportedTargetAction = this.unsupportedTargetAction;
            }
        }

        /// <summary>
        ///   Method invoked at build tome to get the imperative configuration of the current <see cref = "Aspect" />.
        /// </summary>
        /// <param name = "targetElement">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the current <see cref = "Aspect" />
        ///   has been applied.
        /// </param>
        /// <returns>An <see cref = "AspectConfiguration" /> representing the imperative configuration
        ///   of the current <see cref = "Aspect" />.</returns>
        /// <remarks>
        ///   <para>This method can be customized by overriding <see cref = "CreateAspectConfiguration" /> and/or
        ///     <see cref = "SetAspectConfiguration" /></para>.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        public AspectConfiguration GetAspectConfiguration( object targetElement )
        {
            AspectConfiguration aspectConfiguration = this.CreateAspectConfiguration();
            if ( aspectConfiguration != null )
            {
                this.SetAspectConfiguration( aspectConfiguration, targetElement );
            }
            return aspectConfiguration;
        }


        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "target">Code element (<see cref = "Assembly" />, <see cref = "Type" />, 
        ///   <see cref = "FieldInfo" />, <see cref = "MethodBase" />, <see cref = "PropertyInfo" />, <see cref = "EventInfo" />, 
        ///   <see cref = "ParameterInfo" />, or <see cref = "LocationInfo" />) to which the aspect has been applied.</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable target, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( object target )
        {
            return true;
        }


        internal const string XmlNamespace = "http://schemas.postsharp.net/2.0/aspects";
    }
}
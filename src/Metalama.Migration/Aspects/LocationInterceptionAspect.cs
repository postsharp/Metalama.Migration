// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspect that, when applied on a location (field or property), intercepts invocations of
    /// the <c>Get</c> (<see cref="OnGetValue"/>) and <c>Set</c> (<see cref="OnSetValue"/>) semantics.
    /// </summary>
    /// <seealso cref="LocationInterceptionAspectConfigurationAttribute"/>
    /// <remarks>
    /// <para>
    /// This aspect can be applied indifferently to fields and properties, called <i>locations</i> 
    /// because they both have the semantics of a slot where a value can be stored and retrieved.
    /// </para>
    /// <h5>Applying the Aspect on Properties</h5>
    /// <para>Applying an aspect of type <see cref="LocationInterceptionAspect"/> to a property results in the accessors of this property to be replaced by a call to the method <see cref="OnGetValue"/> 
    /// or <see cref="OnSetValue"/> of the current class. The original body of the accessor is moved into a new method, 
    /// which can be called by the aspect by invoking one of the methods 
    /// <see cref="LocationInterceptionArgs.ProceedGetValue"/>, <see cref="LocationInterceptionArgs.ProceedSetValue"/>,
    /// <see cref="LocationInterceptionArgs.GetCurrentValue"/> or <see cref="LocationInterceptionArgs.SetNewValue"/>,
    /// or by using the <see cref="LocationInterceptionArgs.Binding"/> object.</para>
    /// <h5>Applying the Aspect on Fields</h5>
    /// <para>Applying this aspect on a field transforms the field into a property of the same name,
    /// scope and visibility as the original field. The original field is removed. Aspect code can get or set the
    /// value of the field by calling the methods <see cref="LocationInterceptionArgs.ProceedGetValue"/>, 
    /// <see cref="LocationInterceptionArgs.ProceedSetValue"/>,  <see cref="LocationInterceptionArgs.GetCurrentValue"/> 
    /// or <see cref="LocationInterceptionArgs.SetNewValue"/>, or by using the <see cref="LocationInterceptionArgs.Binding"/> object.</para>
    /// <para><note>
    /// Remember to use
    /// <see cref="System.Reflection.PropertyInfo"/> instead of <see cref="System.Reflection.FieldInfo"/> at runtime to reflect the original field.
    /// For this reason, you cannot store a <see cref="System.Reflection.FieldInfo"/> in the aspect. 
    /// Store a <see cref="PostSharp.Reflection.LocationInfo"/>
    /// instead; even if a <see cref="PostSharp.Reflection.LocationInfo"/> represents a field at build time, it will represent
    /// the corresponding <see cref="System.Reflection.PropertyInfo"/> at runtime.</note></para>
    /// <para><note>
    /// When you apply an aspect derived from <see cref="LocationInterceptionAspect"/> to a value-type field, 
    /// you should not pass the value of this field by reference (as an argument to <c>out</c> and <c>ref</c> parameters in C#).
    /// Indeed, PostSharp is unable to detect read and write accesses through references. 
    /// </note></para>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='seeAlsoInterceptionAspects']/*"/>
#if SERIALIZABLE
    [Serializable]
#endif
    [MulticastAttributeUsage( MulticastTargets.Field | MulticastTargets.Property, TargetMemberAttributes = MulticastAttributes.NonLiteral | MulticastAttributes.NonAbstract,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [HasInheritedAttribute]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(LocationInterceptionAspectConfigurationAttribute) )]
    [Serializer(null)]
    public abstract class LocationInterceptionAspect : LocationLevelAspect, ILocationInterceptionAspect, IOnInstanceLocationInitializedAspect
    {
        /// <inheritdoc />
        [RequiresLocationInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        [LocationInterceptionAdviceOptimization( LocationInterceptionAdviceOptimizations.IgnoreAdvice )]
        public virtual void OnGetValue( LocationInterceptionArgs args )
        {
            args.ProceedGetValue();
        }

        /// <inheritdoc />
        [RequiresLocationInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute]
        [LocationInterceptionAdviceOptimization( LocationInterceptionAdviceOptimizations.IgnoreAdvice )]
        public virtual void OnSetValue( LocationInterceptionArgs args )
        {
            args.ProceedSetValue();
        }

        /// <inheritdoc />
        [RequiresLocationInterceptionAdviceAnalysis, RequiresDebuggerEnhancement(DebuggerStepOverAspectBehavior.RunToTarget), HasInheritedAttribute] // TODO document attributes
        [LocationInterceptionAdviceOptimization(LocationInterceptionAdviceOptimizations.IgnoreAdvice)] // TODO what does this mean?
        public virtual void OnInstanceLocationInitialized( LocationInitializationArgs args )
        {
            // Do nothing.
        }


        /// <inheritdoc />
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new LocationInterceptionAspectConfiguration();
        }


    }
}
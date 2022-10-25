// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Configuration;
using PostSharp.Aspects.Internals;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Runtime semantics of an aspect that, when applied on a location (field or property), intercepts invocations of
    ///   the <c>Get</c> (<see cref = "OnGetValue" />) and <c>Set</c> (<see cref = "OnSetValue" />) semantics.
    /// </summary>
    /// <remarks>
    ///   See <see cref = "LocationInterceptionAspect" /> for details.
    /// </remarks>
    /// <see cref = "LocationInterceptionAspect" />
    /// <see cref = "LocationInterceptionAspectConfiguration" />
    /// <see cref = "LocationInterceptionAspectConfigurationAttribute" />
    [HasInheritedAttribute]
    public interface ILocationInterceptionAspect : ILocationLevelAspect
    {
        /// <summary>
        ///   Method invoked <i>instead</i> of the <c>Get</c> semantic of the field or property to which the current aspect is applied,
        ///   i.e. when the value of this field or property is retrieved.
        /// </summary>
        /// <param name = "args">Advice arguments.</param>
        /// <seealso cref = "LocationInterceptionArgs" />
        [RequiresLocationInterceptionAdviceAnalysis, RequiresDebuggerEnhancement( DebuggerStepOverAspectBehavior.RunToTarget ), HasInheritedAttribute]
        void OnGetValue( LocationInterceptionArgs args );

        /// <summary>
        /// Method invoked <i>instead</i> of the <c>Set</c> semantic of the field or property to which the current aspect is applied,
        ///   i.e. when the value of this field or property is changed.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is invoked <i>instead</i> of the setter of the property to which the current aspect is applied. If it is applied to a field, that field
        /// is transformed into a property. This method intercepts all writes to static properties, but it does not intercept inline initializers of instance
        /// properties; use <see cref="IOnInstanceLocationInitializedAspect.OnInstanceLocationInitialized"/> for that.
        /// </para>
        /// <para>
        /// If you apply this advice to a getter-only auto-implemented property, PostSharp will create a setter that will be called in these cases:
        /// </para>
        /// <list type="bullet">
        ///   <item>for static properties, instead of the property inline initialization or property assignment from the static constructor;</item>
        ///   <item>for instance properties, only instead of the property assignment from the constructor but not for the inline initialization
        ///     (use the <see cref="IOnInstanceLocationInitializedAspect.OnInstanceLocationInitialized"/> advice to intercept inline initialization
        /// of an instance property).</item>
        /// </list>
        /// </remarks>
        /// <param name = "args">Advice arguments.</param>
        /// <seealso cref = "LocationInterceptionArgs" />
        [RequiresLocationInterceptionAdviceAnalysis, RequiresDebuggerEnhancement( DebuggerStepOverAspectBehavior.RunToTarget ), HasInheritedAttribute]
        void OnSetValue( LocationInterceptionArgs args );
    }
}
using System;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideFieldOrPropertyAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Field | MulticastTargets.Property,
        TargetMemberAttributes = MulticastAttributes.NonLiteral | MulticastAttributes.NonAbstract,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct,
        AllowMultiple = true )]
    public abstract class LocationInterceptionAspect : LocationLevelAspect, ILocationInterceptionAspect, IOnInstanceLocationInitializedAspect
    {
        /// <inheritdoc/>
        public virtual void OnGetValue( LocationInterceptionArgs args )
        {
            args.ProceedGetValue();
        }

        /// <inheritdoc/>
        public virtual void OnSetValue( LocationInterceptionArgs args )
        {
            args.ProceedSetValue();
        }

        /// <inheritdoc/>
        public virtual void OnInstanceLocationInitialized( LocationInitializationArgs args )
        {
            // Do nothing.
        }

        /// <inheritdoc/>
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new LocationInterceptionAspectConfiguration();
        }
    }
}
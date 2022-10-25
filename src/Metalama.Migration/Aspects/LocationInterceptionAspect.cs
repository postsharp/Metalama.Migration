using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Field | MulticastTargets.Property,
        TargetMemberAttributes = MulticastAttributes.NonLiteral | MulticastAttributes.NonAbstract,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(LocationInterceptionAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class LocationInterceptionAspect : LocationLevelAspect, ILocationInterceptionAspect, IOnInstanceLocationInitializedAspect
    {
        public virtual void OnGetValue( LocationInterceptionArgs args )
        {
            args.ProceedGetValue();
        }

        public virtual void OnSetValue( LocationInterceptionArgs args )
        {
            args.ProceedSetValue();
        }

        public virtual void OnInstanceLocationInitialized( LocationInitializationArgs args )
        {
            // Do nothing.
        }

        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new LocationInterceptionAspectConfiguration();
        }
    }
}
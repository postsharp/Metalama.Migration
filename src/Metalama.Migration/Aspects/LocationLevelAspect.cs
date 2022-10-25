using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Reflection;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Field | MulticastTargets.Property | MulticastTargets.Parameter | MulticastTargets.ReturnValue,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Interface
        | AttributeTargets.Property | AttributeTargets.Struct | AttributeTargets.Parameter |
        AttributeTargets.ReturnValue,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class LocationLevelAspect : Aspect, ILocationLevelAspect, ILocationLevelAspectBuildSemantics
    {
        public virtual void RuntimeInitialize( LocationInfo locationInfo ) { }

        public virtual void CompileTimeInitialize( LocationInfo targetLocation, AspectInfo aspectInfo ) { }

        public virtual bool CompileTimeValidate( LocationInfo locationInfo )
        {
            return true;
        }

        protected virtual void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            LocationInfo targetLocation ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (LocationInfo)targetElement );
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            return CompileTimeValidate( (LocationInfo)target );
        }
    }
}
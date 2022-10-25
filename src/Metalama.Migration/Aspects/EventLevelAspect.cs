using System;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Event,
        AllowExternalAssemblies = false,
        AllowMultiple = true )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Event,
        AllowMultiple = true,
        Inherited = false )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class EventLevelAspect : Aspect, IEventLevelAspect, IEventLevelAspectBuildSemantics
    {
        public virtual void RuntimeInitialize( EventInfo eventInfo ) { }

        public virtual void CompileTimeInitialize( EventInfo targetEvent, AspectInfo aspectInfo ) { }

        public virtual bool CompileTimeValidate( EventInfo targetEvent )
        {
            return true;
        }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, EventInfo targetEvent ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (EventInfo)targetElement );
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            return CompileTimeValidate( (EventInfo)target );
        }
    }
}
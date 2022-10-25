using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [MulticastAttributeUsage( MulticastTargets.Event, AllowMultiple = true, PersistMetaData = false, TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    [AspectConfigurationAttributeType( typeof(EventInterceptionAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class EventInterceptionAspect : EventLevelAspect, IEventInterceptionAspect

    {
        public virtual void OnAddHandler( EventInterceptionArgs args )
        {
            args.ProceedAddHandler();
        }

        public virtual void OnRemoveHandler( EventInterceptionArgs args )
        {
            args.ProceedRemoveHandler();
        }

        public virtual void OnInvokeHandler( EventInterceptionArgs args )
        {
            args.ProceedInvokeHandler();
        }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new EventInterceptionAspectConfiguration();
        }
    }
}
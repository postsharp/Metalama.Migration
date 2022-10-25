using System;
using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage( MulticastTargets.Class, AllowExternalAssemblies = false, TargetTypeAttributes = MulticastAttributes.Instance )]
    [AttributeUsage( AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class InstanceLevelAspect : TypeLevelAspect, ICloneAwareAspect
    {
        public virtual object CreateInstance( AdviceArgs adviceArgs )
        {
            throw new NotImplementedException();
        }

        public virtual void RuntimeInitializeInstance() { }

        public virtual void OnCloned( ICloneAwareAspect source ) { }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        public object Instance { get; }
    }
}
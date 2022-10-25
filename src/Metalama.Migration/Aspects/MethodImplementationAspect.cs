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
        MulticastTargets.Method,
        AllowMultiple = false,
        AllowExternalAssemblies = false,
        PersistMetaData = false,
        Inheritance = MulticastInheritance.None )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class MethodImplementationAspect : MethodLevelAspect, IMethodInterceptionAspect
    {
        public abstract void OnInvoke( MethodInterceptionArgs args );

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }
    }
}
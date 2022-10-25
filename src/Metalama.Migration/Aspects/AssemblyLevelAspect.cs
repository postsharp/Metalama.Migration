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
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [MulticastAttributeUsage( MulticastTargets.Assembly )]
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    [Serializer( null )]
    public abstract class AssemblyLevelAspect : Aspect, IAssemblyLevelAspect, IAssemblyLevelAspectBuildSemantics
    {
        public virtual bool CompileTimeValidate( Assembly assembly )
        {
            return true;
        }

        public sealed override bool CompileTimeValidate( object target )
        {
            return CompileTimeValidate( (Assembly)target );
        }

        public virtual void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo ) { }

        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Assembly targetAssembly ) { }

        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (Assembly)targetElement );
        }
    }
}
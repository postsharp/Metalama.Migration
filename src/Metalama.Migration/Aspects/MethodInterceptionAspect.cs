using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    [Serializable]
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.InstanceConstructor,
        AllowMultiple = true,
        AllowExternalAssemblies = true,
        PersistMetaData = false,
        TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(MethodInterceptionAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class MethodInterceptionAspect : MethodLevelAspect, IMethodInterceptionAspect
                                                   , IAsyncMethodInterceptionAspect

    {
        protected SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        // TODO: This property is redundant. Remove in next major version.
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        public virtual void OnInvoke( MethodInterceptionArgs args )
        {
            args.Proceed();
        }

        public virtual Task OnInvokeAsync( MethodInterceptionArgs args )
        {
            return args.ProceedAsync().GetTask();
        }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }
    }
}
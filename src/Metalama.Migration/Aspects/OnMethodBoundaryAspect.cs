using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    [Serializable]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Interface |
        AttributeTargets.Struct,
        AllowMultiple = true,
        Inherited = false )]
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.StaticConstructor | MulticastTargets.InstanceConstructor,
        AllowMultiple = true,
        TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(OnMethodBoundaryAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class OnMethodBoundaryAspect : MethodLevelAspect, IOnStateMachineBoundaryAspect
    {
        public virtual void OnEntry( MethodExecutionArgs args ) { }

        public virtual void OnExit( MethodExecutionArgs args ) { }

        public virtual void OnSuccess( MethodExecutionArgs args ) { }

        public virtual void OnException( MethodExecutionArgs args ) { }

        protected SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        // TODO: This property is redundant. Remove in next major version.
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnMethodBoundaryAspectConfiguration();
        }

        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }

        public virtual void OnResume( MethodExecutionArgs args ) { }

        public virtual void OnYield( MethodExecutionArgs args ) { }
    }
}
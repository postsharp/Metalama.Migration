using System;
using System.Reflection;
using System.Threading.Tasks;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Use <see cref="OverrideMethodAspect"/>.
    /// </summary>
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.InstanceConstructor,
        AllowMultiple = true,
        PersistMetaData = false,
        TargetMemberAttributes = MulticastAttributes.NonAbstract )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method |
        AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Struct,
        AllowMultiple = true )]
    public abstract class MethodInterceptionAspect : MethodLevelAspect, IMethodInterceptionAspect
                                                   , IAsyncMethodInterceptionAspect

    {
        /// <summary>
        /// In Metalama, implement different methods <see cref="OverrideMethodAspect.OverrideMethod"/>, <see cref="OverrideMethodAspect.OverrideAsyncMethod"/>,
        /// <see cref="OverrideMethodAspect.OverrideEnumerableMethod"/> or <see cref="OverrideMethodAspect.OverrideEnumeratorMethod"/>, and
        /// set the properties <see cref="OverrideMethodAspect.UseAsyncTemplateForAnyAwaitable"/> or <see cref="OverrideMethodAspect.UseEnumerableTemplateForAnyEnumerable"/>.
        /// </summary>
        protected SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        /// <summary>
        /// There is no equivalent in Metalama. Unsupported targets will throw an exception.
        /// </summary>
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        /// <inheritdoc/>
        public virtual void OnInvoke( MethodInterceptionArgs args )
        {
            args.Proceed();
        }

        /// <inheritdoc/>
        public virtual Task OnInvokeAsync( MethodInterceptionArgs args )
        {
            return args.ProceedAsync().GetTask();
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }

        /// <inheritdoc/>
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }
    }
}
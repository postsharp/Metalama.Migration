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
    /// <summary>
    /// Aspect that, when applied on a method, intercepts invocations of this method.
    /// </summary>
    /// <seealso cref="MethodInterceptionAspectConfigurationAttribute"/>
    /// <remarks>
    /// <para>Applying a <see cref="MethodInterceptionAspect"/> to a method results in the body of this method to be replaced by a call to the aspect <see cref="OnInvoke"/> method of the current class. 
    /// The original method body is moved into a new method, which can be called by the aspect by invoking the <see cref="MethodInterceptionArgs.Proceed"/> method,
    /// or by using the object <see cref="MethodInterceptionArgs.Binding"/>.</para>
    /// <note>
    /// PostSharp creates a local copy of all by-reference parameters (<c>in</c>, <c>out</c>, <c>ref</c>) and this local copy is passed to the intercepted method, not the original argument.
    /// This may have unwanted effects on multi-threaded code (because the argument value is not changed at the same moment as before) or when applying the aspect on a P-Invoke method
    /// (because a by-reference parameter could represent the starting address of a larger buffer).
    /// </note>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='seeAlsoInterceptionAspects']/*"/>
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
        /// <summary>
        /// Determines which target methods will be advised semantically. This affects the behavior of the aspect when it's applied to
        /// iterator or async methods, which are compiled into state machines.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Semantic advising results in an aspect that is consistent with the level of abstraction of the programming language. This is the default behavior.
        /// You can disable semantic advising using this property to be consistent with the level of abstraction
        /// of MSIL and for backward-compatibility with the versions of PostSharp prior to 3.1.
        /// </para>
        /// </remarks>
        protected SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        /// <summary>
        /// Specifies the action to take when the aspect is applied to an async method with unsupported return value type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Starting with C#7 async methods can have return types other than <see cref="System.Threading.Tasks.Task"/> or <see cref="System.Threading.Tasks.Task{TResult}"/>.
        /// Async method interception does not support this type of async methods. By default, the build error is raised whenever
        /// async method interception is applied to a method that returns awaitable type other than <see cref="System.Threading.Tasks.Task"/> or <see cref="System.Threading.Tasks.Task{TResult}"/>.
        /// </para>
        /// <para>
        /// Set this property to change how unsupported async methods are handled during compile time.
        /// </para>
        /// </remarks>

        // TODO: This property is redundant. Remove in next major version.
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        /// <inheritdoc />
        public virtual void OnInvoke( MethodInterceptionArgs args )
        {
            args.Proceed();
        }

        /// <inheritdoc />
        public virtual Task OnInvokeAsync( MethodInterceptionArgs args )
        {
            return args.ProceedAsync().GetTask();
        }

        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }

        /// <inheritdoc />
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }
    }
}
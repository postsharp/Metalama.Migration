using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Aspect that, when applied to a method, defines an exception
    /// handler around the whole method and calls a custom method in this exception
    /// handler.
    /// </summary>
    /// <see cref="OnMethodBoundaryAspect"/>
    /// <seealso cref="OnExceptionAspectConfigurationAttribute"/>
    /// <remarks>
    /// <para>
    /// The <see cref="OnExceptionAspect"/> aspect adds an exception handler to the method to which it is applied.
    /// It allows you to easily encapsulate exception handling policies as a custom attribute.</para>
    /// <para>The most important method is <see cref="OnException"/>. It is the exception handler in itself.</para>
    /// <para> The current exception is available from the <see cref="MethodExecutionArgs.Exception"/> property of the <see cref="MethodExecutionArgs"/>
    /// object. This property is read-only. If you need to  replace the current exception by another one, you should throw a new exception 
    /// from the handler. If you need to ignore the exception, set the <see cref="MethodExecutionArgs.FlowBehavior"/> property to
    /// <see cref="FlowBehavior.Continue"/>.</para>
    /// <include file="Documentation.xml" path="/documentation/section[@name='methodExecutionArgs']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    [Serializable]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Property |
        AttributeTargets.Struct | AttributeTargets.Interface,
        AllowMultiple = true,
        Inherited = false )]
    [MulticastAttributeUsage(
        MulticastTargets.Method | MulticastTargets.StaticConstructor | MulticastTargets.InstanceConstructor,
        TargetMemberAttributes =
            MulticastAttributes.NonAbstract | MulticastAttributes.AnyScope | MulticastAttributes.AnyVisibility |
            MulticastAttributes.Managed,
        AllowMultiple = true )]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [AspectConfigurationAttributeType( typeof(OnExceptionAspectConfigurationAttribute) )]
    [Serializer( null )]
    public abstract class OnExceptionAspect : MethodLevelAspect, IOnExceptionAspect
    {
        /// <inheritdoc />
        public virtual void OnException( MethodExecutionArgs args ) { }

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
        /// Specifies the action to take when the aspect is applied to an unsupported target method.
        /// </summary>

        // TODO: This property is redundant. Remove in next major version.
        public new UnsupportedTargetAction UnsupportedTargetAction
        {
            get => base.UnsupportedTargetAction;
            set => base.UnsupportedTargetAction = value;
        }

        /// <summary>
        ///   Gets the type of exception handled by this aspect.
        /// </summary>
        /// <param name = "targetMethod">Method to which the current aspect is applied.</param>
        /// <returns>The type (derived from <see cref = "Exception" />) of exceptions handled
        ///   by this aspect.</returns>
        public virtual Type GetExceptionType( MethodBase targetMethod )
        {
            return null;
        }

        /// <inheritdoc />
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnExceptionAspectConfiguration();
        }

        /// <inheritdoc />
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }
    }
}
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
    /// Aspect that, when applied to a method defined in the current assembly, inserts a piece
    /// of code before and after the body of these methods.
    /// </summary>
    /// <remarks>
    /// <para>The <see cref="OnMethodBoundaryAspect"/> aspect results in the target method to 
    /// be wrapped into a <c>try</c> ... <c>catch</c> ... <c>finally</c> block. You can
    /// implement four advices: <see cref="OnEntry"/>, executed at the beginning of the block;
    /// <see cref="OnSuccess"/>, executed only when the method is successful (i.e. does not
    /// result in an exception); <see cref="OnException"/>, invoked when the method results in 
    /// an exception; and <see cref="OnExit"/>, always executed after method execution
    /// (whether the method resulted in an exception or not).</para>
    /// <para>Schematically, the aspect transforms the original method as follows:</para>
    /// <code lang="c#">
    /// int MyMethod(object arg0, int arg1)
    /// {
    ///    OnEntry();
    ///    try
    ///    {
    ///     // Original method body. 
    ///     OnSuccess();
    ///     return returnValue;
    ///   }
    ///   catch ( Exception e )
    ///   {
    ///     OnException();
    ///   }
    ///   finally
    ///   {
    ///     OnExit();
    ///   }
    /// }
    /// </code>
    /// <para>Note that this code is only schematic; actually generated instructions are 
    /// more complex because they have to cope with parameter boxing and control flow 
    /// modification, among others.
    /// </para>
    /// <include file="Documentation.xml" path="/documentation/section[@name='methodExecutionArgs']/*"/>
    /// <para>
    /// You can apply a method boundary aspect to a method that is outside your assembly. If you do, all calls to that method
    /// are intercepted and replaced with calls to a new method, in your assembly, that calls the original method. When this happens,
    /// by-reference parameters (<c>ref</c>) undergo special treatment similar to what happens in <see cref="MethodInterceptionAspect"/>.
    /// </para>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
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
        /// <inheritdoc />
        public virtual void OnEntry( MethodExecutionArgs args ) { }

        /// <inheritdoc />
        public virtual void OnExit( MethodExecutionArgs args ) { }

        /// <inheritdoc />
        public virtual void OnSuccess( MethodExecutionArgs args ) { }

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

        /// <inheritdoc />
        protected sealed override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnMethodBoundaryAspectConfiguration();
        }

        /// <inheritdoc />
        protected override void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public virtual void OnResume( MethodExecutionArgs args ) { }

        /// <inheritdoc />
        public virtual void OnYield( MethodExecutionArgs args ) { }
    }
}
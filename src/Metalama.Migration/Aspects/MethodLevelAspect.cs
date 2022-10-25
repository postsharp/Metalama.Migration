using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for all aspects applied on methods.
    /// </summary>
    /// <seealso cref="IMethodLevelAspect"/>
    /// <remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    [Serializable]
    [SuppressMessage( "Microsoft.Naming", "CA1710" /* IdentifiersShouldHaveCorrectSuffix */ )]
    [MulticastAttributeUsage( MulticastTargets.Method | MulticastTargets.InstanceConstructor | MulticastTargets.StaticConstructor )]
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property |
        AttributeTargets.Event | AttributeTargets.Method | AttributeTargets.Constructor,
        AllowMultiple = true )]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [Serializer( null )]
    public abstract class MethodLevelAspect : Aspect, IMethodLevelAspect, IMethodLevelAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "method">Method to which the aspect has been applied</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable field, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( MethodBase method )
        {
            return true;
        }

        /// <inheritdoc />
        public sealed override bool CompileTimeValidate( object target )
        {
            var method = target as MethodBase;

            if (method == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Aspects of type {0} can be applied to methods only.",
                        GetType().FullName ) );
            }

            return CompileTimeValidate( method );
        }

        /// <inheritdoc />
        public virtual void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo ) { }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "Aspect.CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetMethod">Method to which the current aspect has been applied.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the 
        ///     <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, MethodBase targetMethod ) { }

        /// <inheritdoc />
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (MethodBase)targetElement );
        }

        /// <inheritdoc />
        public virtual void RuntimeInitialize( MethodBase method ) { }
    }
}
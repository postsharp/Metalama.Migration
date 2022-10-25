using System;
using System.Diagnostics;
using System.Reflection;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;
using PostSharp.Serialization;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// Base class for all aspects applied on assemblies.
    /// </summary>
    /// <seealso cref="IAssemblyLevelAspect"/>
    /// <remarks>
    /// <include file="Documentation.xml" path="/documentation/section[@name='abstractAspectClass']/*"/>
    /// <br/>
    /// <include file="Documentation.xml" path="/documentation/section[@name='aspectSerialization']/*"/>
    /// </remarks>
    [Serializable]
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    [MulticastAttributeUsage( MulticastTargets.Assembly )]
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    [Serializer( null )]
    public abstract class AssemblyLevelAspect : Aspect, IAssemblyLevelAspect, IAssemblyLevelAspectBuildSemantics
    {
        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to the right target.
        /// </summary>
        /// <param name = "assembly">Assembly on which the current aspect is applied.</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable target, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message (see 
        ///   <see cref = "MessageSource" />) or an exception in case of error. Returning <c>false</c> without emitting an
        ///   error message or exception causes the aspect to be silently ignored.
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoValidatingAspects']/*" />
        public virtual bool CompileTimeValidate( Assembly assembly )
        {
            return true;
        }

        /// <inheritdoc />
        public sealed override bool CompileTimeValidate( object target )
        {
            return CompileTimeValidate( (Assembly)target );
        }

        /// <inheritdoc />
        public virtual void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo ) { }

        /// <summary>
        ///   Method invoked at build time to set up an <see cref = "AspectConfiguration" /> object according to the current 
        ///   <see cref = "Aspect" /> instance and a specified target element of the current aspect.
        /// </summary>
        /// <param name = "aspectConfiguration">The <see cref = "AspectConfiguration" /> instance previously returned  by the
        ///   <see cref = "Aspect.CreateAspectConfiguration" /> method.</param>
        /// <param name = "targetAssembly">Assembly to which the current aspect has been applied.</param>
        /// <remarks>
        ///   <para>Classes overriding this method must always invoke the base implementation before performing their own
        ///     changes to the 
        ///     <see cref = "AspectConfiguration" />.</para>
        /// </remarks>
        /// <include file = "Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Assembly targetAssembly ) { }

        /// <inheritdoc />
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (Assembly)targetElement );
        }
    }
}
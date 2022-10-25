using System;
using System.Reflection;
using Metalama.Framework.Aspects;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="CompilationAspect"/>.
    /// </summary>
    [MulticastAttributeUsage( MulticastTargets.Assembly )]
    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    public abstract class AssemblyLevelAspect : Aspect, IAssemblyLevelAspect, IAssemblyLevelAspectBuildSemantics
    {
        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( Assembly assembly )
        {
            return true;
        }

        /// <inheritdoc/>
        public sealed override bool CompileTimeValidate( object target )
        {
            return CompileTimeValidate( (Assembly)target );
        }

        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        public virtual void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo ) { }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, Assembly targetAssembly ) { }

        /// <inheritdoc/>
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (Assembly)targetElement );
        }
    }
}
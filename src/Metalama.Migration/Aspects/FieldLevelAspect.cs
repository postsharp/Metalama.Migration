using System;
using System.Reflection;
using Metalama.Framework.Aspects;
using Metalama.Framework.Eligibility;
using PostSharp.Aspects.Configuration;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="FieldOrPropertyAspect"/>.
    /// </summary>
    public abstract class FieldLevelAspect : Aspect, IFieldLevelAspect, IFieldLevelAspectBuildSemantics
    {
        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( FieldInfo field )
        {
            return true;
        }

        /// <inheritdoc/>
        public sealed override bool CompileTimeValidate( object target )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, aspect initialization is done in <see cref="IAspect{T}.BuildAspect"/>.
        /// </summary>
        public virtual void CompileTimeInitialize( FieldInfo field, AspectInfo aspectInfo ) { }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, FieldInfo targetField ) { }

        /// <inheritdoc/>
        protected sealed override void SetAspectConfiguration(
            AspectConfiguration aspectConfiguration,
            object targetElement )
        {
            base.SetAspectConfiguration( aspectConfiguration, targetElement );
            SetAspectConfiguration( aspectConfiguration, (FieldInfo)targetElement );
        }

        /// <inheritdoc/>
        public virtual void RuntimeInitialize( FieldInfo field ) { }
    }
}
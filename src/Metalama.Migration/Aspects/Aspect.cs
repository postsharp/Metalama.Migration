using System;
using Metalama.Framework.Aspects;
using Metalama.Framework.Eligibility;
using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// The base aspect class in Metalama is <see cref="Metalama.Framework.Aspects.Aspect"/>.
    /// </summary>
    public abstract class Aspect : MulticastAttribute, IAspect, IAspectBuildSemantics
    {
        /// <summary>
        /// It is not possible to set the aspect priority on a per-instance basis in Metalama. Instead, all aspects are
        /// statically ordered using the <see cref="AspectOrderAttribute"/> custom attribute.
        /// </summary>
        /// <seealso href="@ordering"/>
        [Obsolete( "", true )]
        public int AspectPriority { get; set; }

        /// <summary>
        /// Aspect are also serializable in Metalama, but the serializer cannot be customized.
        /// </summary>
        protected Type SerializerType { get; set; }

        /// <summary>
        /// In Metalama, it is not possible to customize the behavior when the aspect is applied to an unsupported target. An exception will be thrown.
        /// </summary>
        public UnsupportedTargetAction UnsupportedTargetAction { get; set; }

        /// <inheritdoc/>
        bool IValidableAnnotation.CompileTimeValidate( object target )
        {
            return CompileTimeValidate( target );
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual AspectConfiguration CreateAspectConfiguration()
        {
            return new AspectConfiguration();
        }

        /// <summary>
        /// Not supported in Metalama.
        /// </summary>
        protected virtual void SetAspectConfiguration( AspectConfiguration aspectConfiguration, object targetElement )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public AspectConfiguration GetAspectConfiguration( object targetElement )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        public virtual bool CompileTimeValidate( object target )
        {
            return true;
        }
    }
}
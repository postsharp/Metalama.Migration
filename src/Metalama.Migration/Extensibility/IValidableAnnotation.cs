using Metalama.Framework.Aspects;

namespace PostSharp.Extensibility
{
    [RequirePostSharp( null, "ValidateAnnotations" )]
    public interface IValidableAnnotation
    {
        /// <summary>
        /// In Metalama, validation is done in <see cref="IEligible{T}.BuildEligibility"/> and <see cref="IAspect{T}.BuildAspect"/>.
        /// The equivalent of returning <c>false</c> is to call <see cref="IAspectBuilder.SkipAspect"/>.
        /// </summary>
        bool CompileTimeValidate( object target );
    }
}
using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Interface that, when implemented by a custom attribute (<see cref = "Attribute" />),
    ///   causes <c>PostSharp</c> to invoke a validation method for every instance
    ///   of that custom attribute.
    /// </summary>
    [RequirePostSharp( null, "ValidateAnnotations" )]
    public interface IValidableAnnotation
    {
        /// <summary>
        ///   Method invoked at build time to ensure that the aspect has been applied to
        ///   the right target.
        /// </summary>
        /// <param name = "target">Target element.</param>
        /// <returns><c>true</c> if the aspect was applied to an acceptable target, otherwise
        ///   <c>false</c>.</returns>
        /// <remarks>
        ///   The implementation of this method is expected to emit an error message
        ///   or an exception of type <see cref = "InvalidAnnotationException" /> in case of error. Only returning <c>false</c> causes the aspect
        ///   to be silently ignored.
        /// </remarks>
        bool CompileTimeValidate( object target );
    }
}
using System;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Service that allows build-time code to push annotations (both programmatic and user-visible)
    /// to PostSharp Tools for Visual Studio.
    /// </summary>
    [InternalImplement]
    public interface IWeavingSymbolsService : IService
    {
        /// <summary>
        /// Pushes an annotation to PostSharp Tools for Visual Studio.
        /// </summary>
        /// <param name="targetDeclaration">The declaration to which the annotation relate.</param>
        /// <param name="annotationClass">The type of the annotation.</param>
        /// <param name="arguments">Arguments of the annotation.</param>
        /// <param name="description">A human-readable description of the annotation.</param>
        /// <param name="linesOfCodeAvoided">A number incrementing the number of lines of code saved on <paramref name="targetDeclaration"/>.</param>
        void PushAnnotation(
            object targetDeclaration,
            Type annotationClass = null,
            string arguments = null,
            string description = null,
            int linesOfCodeAvoided = 0 );
    }
}
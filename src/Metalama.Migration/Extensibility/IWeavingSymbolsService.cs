using System;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    [InternalImplement]
    public interface IWeavingSymbolsService : IService
    {
        void PushAnnotation(
            object targetDeclaration,
            Type annotationClass = null,
            string arguments = null,
            string description = null,
            int linesOfCodeAvoided = 0 );
    }
}
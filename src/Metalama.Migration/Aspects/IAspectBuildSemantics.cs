using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    [SuppressAnnotationValidation]
    public interface IAspectBuildSemantics : IValidableAnnotation
    {
        AspectConfiguration GetAspectConfiguration( object targetElement );
    }
}
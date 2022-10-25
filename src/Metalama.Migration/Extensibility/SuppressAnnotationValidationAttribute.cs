using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Instructs PostSharp that the validation of <see cref="IValidableAnnotation"/> is done by another component, and should
    /// not be processed by the default component.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface )]
    public class SuppressAnnotationValidationAttribute : Attribute { }
}
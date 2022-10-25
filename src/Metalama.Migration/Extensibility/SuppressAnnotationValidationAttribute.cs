using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface )]
    public class SuppressAnnotationValidationAttribute : Attribute { }
}
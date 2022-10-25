using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Interface )]
    public class SuppressAnnotationValidationAttribute : Attribute { }
}
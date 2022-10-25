using System;

namespace PostSharp.Aspects.Advices
{
    [AttributeUsage( AttributeTargets.Parameter )]
    public abstract class AdviceParameterAttribute : Attribute
    {
        protected AdviceParameterAttribute() { }
    }
}
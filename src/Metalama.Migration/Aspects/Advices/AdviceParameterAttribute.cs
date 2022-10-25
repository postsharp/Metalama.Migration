using System;

namespace PostSharp.Aspects.Advices
{
    /// <exclude />
    [AttributeUsage( AttributeTargets.Parameter )]
    public abstract class AdviceParameterAttribute : Attribute
    {
        /// <exclude/>
        protected AdviceParameterAttribute() { }
    }
}
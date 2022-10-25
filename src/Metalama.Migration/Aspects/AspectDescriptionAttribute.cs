using System;

namespace PostSharp.Aspects
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class AspectDescriptionAttribute : Attribute
    {
        public AspectDescriptionAttribute( string description )
        {
            Description = description;
        }

        public string Description { get; }
    }
}
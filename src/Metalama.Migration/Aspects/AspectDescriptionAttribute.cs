using System;
using System.ComponentModel;

namespace PostSharp.Aspects
{
    /// <summary>
    /// In Metalama, use <see cref="DescriptionAttribute"/>.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class AspectDescriptionAttribute : Attribute
    {
        public AspectDescriptionAttribute( string description )
        {
            Description = description;
        }

        public string Description { get; }
    }
}
using System;
using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Custom attribute that, when applied to an aspect class, specifies a human-readable description of the aspect
    /// that can be displayed in PostSharp Tools for Visual Studio.
    /// </summary>
    /// <remarks>
    /// <para>This attribute is intended to be used on simple aspects like <see cref="OnMethodBoundaryAspect"/> or
    /// <see cref="MethodInterceptionArgs"/>. For composite aspects, specify the description of each advice
    /// using the <see cref="Advice.Description"/> property.</para>
    /// </remarks>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false )]
    public sealed class AspectDescriptionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AspectDescriptionAttribute"/> class.
        /// </summary>
        /// <param name="description">A human-readable description of the aspect class to which
        /// the <see cref="AspectDescriptionAttribute"/> custom attribute is applied.</param>
        public AspectDescriptionAttribute( string description )
        {
            Description = description;
        }

        /// <summary>
        /// Gets a human-readable description of the aspect class to which
        /// the <see cref="AspectDescriptionAttribute"/> custom attribute is applied.
        /// </summary>
        public string Description { get; }
    }
}
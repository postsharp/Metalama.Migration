using Metalama.Framework.Aspects;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no specific aspect class to add a custom attribute in Metalama, but only the advice factory method
    /// <see cref="IntroduceAttribute"/>. Create an aspect class that calls this advice factory method
    /// from <see cref="IAspect{T}.BuildAspect"/>.
    /// </summary>
    public interface ICustomAttributeIntroductionAspect : IAspect { }
}
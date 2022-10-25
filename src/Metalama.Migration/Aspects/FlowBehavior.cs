using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama because <see cref="OnMethodBoundaryAspect"/> is implemented
    /// with <see cref="OverrideMethodAspect"/> as a method template, therefore you have full control
    /// on the control flow.
    /// </summary>
    public enum FlowBehavior
    {
        Default = 0,

        Continue = 1,

        RethrowException = 2,

        Return = 3,

        ThrowException = 4,

        Yield = 5
    }
}
using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent in Metalama, and there is currently no way to implement this feature differently.
    /// </summary>
    [Obsolete( "", true )]
    public sealed class AwaiterAttribute : AdviceParameterAttribute { }
}
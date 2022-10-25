using Metalama.Framework.Aspects;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Equivalent to <see cref="ContractDirection"/>.
    /// </summary>
    public enum LocationValidationContext
    {
        None = 0,

        Precondition = 1,

        SuccessPostcondition = 2
    }
}
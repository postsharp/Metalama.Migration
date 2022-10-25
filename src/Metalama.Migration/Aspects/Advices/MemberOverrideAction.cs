using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, equivalent to <see cref="OverrideStrategy"/>.
    /// </summary>
    public enum MemberOverrideAction
    {
        Default,

        Fail = Default,

        Ignore = 1,

        OverrideOrFail,

        OverrideOrIgnore
    }
}
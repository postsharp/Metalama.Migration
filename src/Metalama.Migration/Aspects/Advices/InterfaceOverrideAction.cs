using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, equivalent to <see cref="OverrideStrategy"/>.
    /// </summary>
    public enum InterfaceOverrideAction
    {
        Default = 0,

        Fail = Default,

        Ignore
    }
}
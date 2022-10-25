using Metalama.Framework.Aspects;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use <see cref="OverrideStrategy"/>.
    /// </summary>
    public enum CustomAttributeOverrideAction
    {
        Default,

        Fail = Default,

        Ignore,

        Add,

        MergeAddProperty,

        MergeReplaceProperty
    }
}
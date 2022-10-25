namespace PostSharp.Aspects.Advices
{
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
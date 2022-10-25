namespace PostSharp.Aspects.Advices
{
    public enum MemberOverrideAction
    {
        Default,

        Fail = Default,

        Ignore = 1,

        OverrideOrFail,

        OverrideOrIgnore
    }
}
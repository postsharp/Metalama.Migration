namespace PostSharp.Aspects
{
    public enum UnsupportedTargetAction
    {
        Default = 0,

        Fail = Default,

        Ignore,

        Fallback
    }
}
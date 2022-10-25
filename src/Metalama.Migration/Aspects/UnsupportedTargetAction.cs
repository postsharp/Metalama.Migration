namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama because Metalama will throw an exception if the target is not supported.
    /// </summary>
    public enum UnsupportedTargetAction
    {
        Default = 0,

        Fail = Default,

        Ignore,

        Fallback
    }
}
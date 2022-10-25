namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// There is no equivalent to this advice in Metalama because there is no concept of run-time aspect initialization.
    /// </summary>
    public enum AspectInitializationReason
    {
        None,

        Manual,

        Constructor,

        Clone,

        Deserialize
    }
}
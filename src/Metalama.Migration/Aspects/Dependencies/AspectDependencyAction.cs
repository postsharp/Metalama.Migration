namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    /// In Metalama, the only aspect dependency kind is <see cref="Order"/>.
    /// </summary>
    public enum AspectDependencyAction
    {
        None,

        Order,

        Require,

        Conflict,

        Commute
    }
}
namespace PostSharp.Aspects.Dependencies
{
    public enum AspectDependencyAction
    {
        None,

        Order,

        Require,

        Conflict,

        Commute
    }
}
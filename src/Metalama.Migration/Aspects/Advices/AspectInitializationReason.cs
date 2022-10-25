namespace PostSharp.Aspects.Advices
{
    public enum AspectInitializationReason
    {
        None,

        Manual,

        Constructor,

        Clone,

        Deserialize
    }
}
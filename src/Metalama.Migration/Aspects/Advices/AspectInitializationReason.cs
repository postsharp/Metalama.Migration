namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// Enumerates the reasons why the target method of the <see cref="InitializeAspectInstanceAdvice"/> has been invoked.
    /// </summary>
    public enum AspectInitializationReason
    {
        /// <summary>
        /// None.
        /// </summary>
        None,

        /// <summary>
        /// Manual call of the <c>InitializeAspects</c> method.
        /// </summary>
        Manual,

        /// <summary>
        /// Call from the instance constructor.
        /// </summary>
        Constructor,

        /// <summary>
        /// Call from <c>MemberwiseClone</c>.
        /// </summary>
        Clone,

        /// <summary>
        /// Call during deserialization.
        /// </summary>
        Deserialize
    }
}
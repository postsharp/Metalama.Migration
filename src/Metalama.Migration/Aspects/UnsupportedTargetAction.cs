namespace PostSharp.Aspects
{
    /// <summary>
    /// Enumerates actions that can be taken when an aspect is applied to a target element that is not currently supported.
    /// </summary>
    public enum UnsupportedTargetAction
    {
        /// <summary>
        /// Same as <see cref="Fail"/>.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Emit a build-time error when the target declaration is not supported by the aspect. This is the default behavior.
        /// </summary>
        Fail = Default,

        /// <summary>
        /// Do not apply the advice when the target declaration is not supported but do not emit a build error.
        /// </summary>
        Ignore,

        /// <summary>
        /// Fall back to a supported advising strategy if any is available, e.g. from semantic advising (taking into account async semantics) to non-semantic advising.
        /// If no fallback is available, emit a build-time error.
        /// </summary>
        Fallback
    }
}
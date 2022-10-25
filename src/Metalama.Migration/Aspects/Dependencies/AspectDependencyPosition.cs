namespace PostSharp.Aspects.Dependencies
{
    /// <summary>
    ///   Enumeration of the direction of the relationship specified by an aspect dependency.
    /// </summary>
    public enum AspectDependencyPosition
    {
        /// <summary>
        ///   Any order possible (or order not relevant).
        /// </summary>
        Any = 0,

        /// <summary>
        ///   The current aspect or advice is positioned before the other aspect or handler.
        /// </summary>
        Before = -1,

        /// <summary>
        ///   The current aspect or advice is positioned after the other aspect or handler.
        /// </summary>
        After = 1
    }
}
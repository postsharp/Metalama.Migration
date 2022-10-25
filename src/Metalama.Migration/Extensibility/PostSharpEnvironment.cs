namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides access to the current <c>PostSharp</c> environment (<see cref = "IPostSharpEnvironment" />).
    /// </summary>
    public static class PostSharpEnvironment
    {
        /// <summary>
        ///   Gets the current <c>PostSharp</c> environment, or <c>null</c>
        ///   if the <c>PostSharp</c> Platform is not loaded in the current
        ///   context.
        /// </summary>
        public static IPostSharpEnvironment Current { get; }

        /// <summary>
        /// Gets the current PostSharp project.
        /// </summary>
        public static IProject CurrentProject { get; }

        /// <summary>
        ///   Determines whether the <c>PostSharp</c> Platform is currently loaded.
        /// </summary>
        public static bool IsPostSharpRunning { get; }
    }
}
using Metalama.Framework.Project;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="MetalamaExecutionContext"/>.
    /// </summary>
    public static class PostSharpEnvironment
    {
        public static IPostSharpEnvironment Current { get; }

        public static IProject CurrentProject { get; }

        /// <summary>
        /// No equivalent in Metalama.
        /// </summary>
        public static bool IsPostSharpRunning { get; }
    }
}
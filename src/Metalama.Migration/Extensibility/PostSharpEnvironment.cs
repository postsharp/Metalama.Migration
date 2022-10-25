namespace PostSharp.Extensibility
{
    public static class PostSharpEnvironment
    {
        public static IPostSharpEnvironment Current { get; }

        public static IProject CurrentProject { get; }

        public static bool IsPostSharpRunning { get; }
    }
}
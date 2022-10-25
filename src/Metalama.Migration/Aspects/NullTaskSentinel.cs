namespace PostSharp.Aspects
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public sealed class NullTaskSentinel
    {
        static NullTaskSentinel()
        {
            Instance = new NullTaskSentinel();
        }

        public static NullTaskSentinel Instance { get; }
    }
}
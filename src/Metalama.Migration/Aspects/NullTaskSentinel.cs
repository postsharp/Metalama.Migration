namespace PostSharp.Aspects
{
    public sealed class NullTaskSentinel
    {
        static NullTaskSentinel()
        {
            Instance = new NullTaskSentinel();
        }

        public static NullTaskSentinel Instance { get; }
    }
}
namespace PostSharp
{
    public static class Post
    {
        public static TTarget Cast<TSource, TTarget>( TSource o )
            where TSource : class
            where TTarget : class
        {
            return (TTarget)(object)o;
        }

        public static bool IsTransformed { get; }

#pragma warning disable IDE0060, CA1801 // Remove unused parameter

        public static ref T GetMutableRef<T>( in T reference )
#pragma warning restore IDE0060, CA1801 // Remove unused parameter
        {
            // Dummy code to make things compile.
            return ref DefaultValue<T>.Value;
        }

        public static T GetValue<T>( T value ) where T : struct
        {
            return value;
        }

        private static class DefaultValue<T>
        {
            public static T Value;
        }
    }
}
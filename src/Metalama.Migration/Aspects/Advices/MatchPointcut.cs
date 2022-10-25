namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    /// <exclude />
    public sealed class MatchPointcut : Pointcut
    {
        /// <exclude />
        public MatchPointcut( string methodName )
        {
            MethodName = methodName;
        }

        /// <exclude />
        public bool MatchParameterCount { get; set; } = true;

        /// <exclude />
        public string MethodName { get; }
    }
}
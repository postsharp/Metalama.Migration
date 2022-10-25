namespace PostSharp.Aspects.Advices
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    public sealed class MatchPointcut : Pointcut
    {
        public MatchPointcut( string methodName )
        {
            MethodName = methodName;
        }

        public bool MatchParameterCount { get; set; } = true;

        public string MethodName { get; }
    }
}
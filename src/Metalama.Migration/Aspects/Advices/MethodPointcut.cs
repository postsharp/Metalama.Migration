#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    public sealed class MethodPointcut : Pointcut
    {
        public MethodPointcut( string methodName )
        {
            MethodName = methodName;
        }

        public string MethodName { get; }
    }
}
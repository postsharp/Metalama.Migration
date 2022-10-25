#pragma warning disable CA1710 // Identifiers should have correct suffix

using PostSharp.Extensibility;

namespace PostSharp.Aspects.Advices
{
    public sealed class MulticastPointcut : Pointcut
    {
        public string MemberName { get; set; }

        public MulticastTargets Targets { get; set; }

        public MulticastAttributes Attributes { get; set; }
    }
}
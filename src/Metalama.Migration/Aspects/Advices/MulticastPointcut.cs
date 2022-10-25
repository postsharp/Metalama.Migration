#pragma warning disable CA1710 // Identifiers should have correct suffix

using PostSharp.Extensibility;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, you should use a programmatic approach. Use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate the code model exposed on <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    public sealed class MulticastPointcut : Pointcut
    {
        public string MemberName { get; set; }

        public MulticastTargets Targets { get; set; }

        public MulticastAttributes Attributes { get; set; }
    }
}
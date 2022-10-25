using Metalama.Framework.Aspects;

#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, use a <c>foreach</c> loop in the <see cref="Metalama.Framework.Aspects.IAspect{T}.BuildAspect"/> method, iterate the code model exposed on <c>builder</c>.<see cref="IAspectBuilder{TAspectTarget}.Target"/>, and add advice using methods of <c>builder</c>.<see cref="IAspectBuilder.Advice"/>.
    /// </summary>
    public sealed class MethodPointcut : Pointcut
    {
        public MethodPointcut( string methodName )
        {
            MethodName = methodName;
        }

        public string MethodName { get; }
    }
}
#pragma warning disable CA1710 // Identifiers should have correct suffix

namespace PostSharp.Aspects.Advices
{
    public abstract class OnMethodInvokeBaseAdvice : GroupingAdvice
    {
        public SemanticallyAdvisedMethodKinds SemanticallyAdvisedMethodKinds { get; set; }

        public UnsupportedTargetAction UnsupportedTargetAction { get; set; }
    }
}
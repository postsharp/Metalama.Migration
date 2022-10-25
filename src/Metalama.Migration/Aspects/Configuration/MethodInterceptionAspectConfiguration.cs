namespace PostSharp.Aspects.Configuration
{
    public sealed class MethodInterceptionAspectConfiguration : AspectConfiguration
    {
        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}
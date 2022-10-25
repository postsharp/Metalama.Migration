namespace PostSharp.Aspects.Configuration
{
    public sealed class OnMethodBoundaryAspectConfiguration : AspectConfiguration
    {
        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}
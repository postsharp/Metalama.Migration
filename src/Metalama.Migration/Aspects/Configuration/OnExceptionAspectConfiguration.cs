namespace PostSharp.Aspects.Configuration
{
    public sealed class OnExceptionAspectConfiguration : AspectConfiguration
    {
        public TypeIdentity ExceptionType { get; set; }

        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}
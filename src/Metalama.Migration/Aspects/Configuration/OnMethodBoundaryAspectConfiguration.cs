namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public sealed class OnMethodBoundaryAspectConfiguration : AspectConfiguration
    {
        public SemanticallyAdvisedMethodKinds? SemanticallyAdvisedMethodKinds { get; set; }
    }
}
namespace PostSharp.Aspects.Configuration
{
    public sealed class OnMethodBoundaryAspectConfigurationAttribute : AspectConfigurationAttribute

    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnMethodBoundaryAspectConfiguration();
        }
    }
}
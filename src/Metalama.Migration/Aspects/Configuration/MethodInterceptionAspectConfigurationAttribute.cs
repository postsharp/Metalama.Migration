namespace PostSharp.Aspects.Configuration
{
    public sealed class MethodInterceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }
    }
}
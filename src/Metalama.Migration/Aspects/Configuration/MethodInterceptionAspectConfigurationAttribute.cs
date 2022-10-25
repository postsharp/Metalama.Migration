namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no declarative aspect configuration in Metalama.
    /// </summary>
    public sealed class MethodInterceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new MethodInterceptionAspectConfiguration();
        }
    }
}
namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no declarative aspect configuration in Metalama.
    /// </summary>
    public sealed class EventInterceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new EventInterceptionAspectConfiguration();
        }
    }
}
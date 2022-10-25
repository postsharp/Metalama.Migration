namespace PostSharp.Aspects.Configuration
{
    public sealed class EventInterceptionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new EventInterceptionAspectConfiguration();
        }
    }
}
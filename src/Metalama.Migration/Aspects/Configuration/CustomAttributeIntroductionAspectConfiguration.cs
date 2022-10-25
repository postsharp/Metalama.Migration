using PostSharp.Reflection;

namespace PostSharp.Aspects.Configuration
{
    public sealed class CustomAttributeIntroductionAspectConfiguration : AspectConfiguration
    {
        public ObjectConstruction ObjectConstruction { get; set; }
    }
}
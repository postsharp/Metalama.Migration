using PostSharp.Reflection;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public sealed class CustomAttributeIntroductionAspectConfiguration : AspectConfiguration
    {
        public ObjectConstruction ObjectConstruction { get; set; }
    }
}
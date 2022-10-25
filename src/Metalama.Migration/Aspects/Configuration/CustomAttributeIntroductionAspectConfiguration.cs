using PostSharp.Reflection;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Configuration of aspects of type <see cref = "CustomAttributeIntroductionAspect" />.
    /// </summary>
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class CustomAttributeIntroductionAspectConfiguration : AspectConfiguration
    {
        /// <summary>
        ///   Gets or sets the construction of the custom attribute that must be applied to the target of this aspect.
        /// </summary>
        public ObjectConstruction ObjectConstruction { get; set; }
    }
}
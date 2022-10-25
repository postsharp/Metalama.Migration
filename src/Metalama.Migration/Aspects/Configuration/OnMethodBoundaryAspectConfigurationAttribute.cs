namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    ///   Custom attribute that, when applied on a class implementing <see cref = "IOnMethodBoundaryAspect" />,
    ///   defines the configuration of that aspect.
    /// </summary>
    /// <seealso cref = "OnMethodBoundaryAspectConfiguration" />
    /// <seealso cref = "OnMethodBoundaryAspect" />
    /// <include file = "../Documentation.xml" path = "/documentation/section[@name='seeAlsoConfiguringAspects']/*" />
    public sealed class OnMethodBoundaryAspectConfigurationAttribute : AspectConfigurationAttribute

    {
        /// <inheritdoc />
        protected override AspectConfiguration CreateAspectConfiguration()
        {
            return new OnMethodBoundaryAspectConfiguration();
        }
    }
}
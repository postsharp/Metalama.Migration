namespace PostSharp.Extensibility
{
    /// <summary>
    /// Represents a custom element (or section) in the XML project type.
    /// </summary>
    public sealed class ProjectExtensionElement
    {
        /// <summary>
        /// Gets the local name of the custom element.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the XML namespace of the custom element.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// Gets the <c>XElement</c> materializing the project extension.
        /// </summary>
        public object XElement { get; }
    }
}
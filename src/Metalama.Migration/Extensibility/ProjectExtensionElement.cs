namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="Metalama.Framework.Project.ProjectExtension"/>. However, all project extensions are programmatic.
    /// Metalama does not support XML configuration.
    /// </summary>
    public sealed class ProjectExtensionElement
    {
        public string Name { get; }

        public string Namespace { get; }

        public object XElement { get; }
    }
}
namespace PostSharp.Extensibility
{
    public sealed class ProjectExtensionElement
    {
        public string Name { get; }

        public string Namespace { get; }

        public object XElement { get; }
    }
}
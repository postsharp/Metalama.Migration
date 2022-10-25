using PostSharp.Aspects.Dependencies;

#pragma warning disable CA2227 // Collection properties should be read only

namespace PostSharp.Aspects.Configuration
{
    public class AspectConfiguration
    {
        public int? AspectPriority { get; set; }

        public TypeIdentity SerializerType { get; set; }

        public AspectDependencyAttributeCollection Dependencies { get; set; }

        public UnsupportedTargetAction? UnsupportedTargetAction { get; set; }
    }
}
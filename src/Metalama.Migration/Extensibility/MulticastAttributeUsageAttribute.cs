using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public sealed class MulticastAttributeUsageAttribute : Attribute
    {
        public MulticastAttributeUsageAttribute( MulticastTargets validOn )
        {
            throw new NotImplementedException();
        }

        public MulticastAttributeUsageAttribute() { }

        public MulticastTargets ValidOn { get; }

        public bool AllowMultiple { get; set; }

        public MulticastInheritance Inheritance { get; set; }

        public bool AllowExternalAssemblies { get; set; }

        public bool PersistMetaData { get; set; }

        public MulticastAttributes TargetMemberAttributes { get; set; }

        public MulticastAttributes TargetExternalMemberAttributes { get; set; }

        public MulticastAttributes TargetParameterAttributes { get; set; }

        public MulticastAttributes TargetTypeAttributes { get; set; }

        public MulticastAttributes TargetExternalTypeAttributes { get; set; }
    }
}
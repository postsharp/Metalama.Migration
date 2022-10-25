using System;

namespace PostSharp.Extensibility
{
    public abstract class MulticastAttribute : Attribute
    {
        [AspectSerializerIgnore]
        public MulticastTargets AttributeTargetElements { get; set; }

        [AspectSerializerIgnore]
        public string AttributeTargetAssemblies { get; set; }

        [AspectSerializerIgnore]
        public string AttributeTargetTypes { get; set; }

        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetTypeAttributes { get; set; }

        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetExternalTypeAttributes { get; set; }

        [AspectSerializerIgnore]
        public string AttributeTargetMembers { get; set; }

        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetMemberAttributes { get; set; }

        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetExternalMemberAttributes { get; set; }

        [AspectSerializerIgnore]
        public string AttributeTargetParameters { get; set; }

        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetParameterAttributes { get; set; }

        [AspectSerializerIgnore]
        public bool AttributeExclude { get; set; }

        [AspectSerializerIgnore]
        public int AttributePriority { get; set; }

        [AspectSerializerIgnore]
        public bool AttributeReplace { get; set; }

        [AspectSerializerIgnore]
        public MulticastInheritance AttributeInheritance { get; set; }

        // TODO: Used in compiler.

        [Obsolete( "Do not use this property in customer code.", true )]
        [AspectSerializerIgnore]
        public long AttributeId { get; set; }
    }
}
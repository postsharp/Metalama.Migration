using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Okay, this one is problematic. There is no declarative (attribute-based) multicasting in Metalama. Instead, fabrics should be used.
    /// However, we plan to build some backward-compatibility layer for customers who have a lot of multicasting.
    /// </summary>
    /// <seealso href="@fabrics-aspects"/>
    public abstract class MulticastAttribute : Attribute
    {
        public MulticastTargets AttributeTargetElements { get; set; }

        public string AttributeTargetAssemblies { get; set; }

        public string AttributeTargetTypes { get; set; }

        public MulticastAttributes AttributeTargetTypeAttributes { get; set; }

        public MulticastAttributes AttributeTargetExternalTypeAttributes { get; set; }

        public string AttributeTargetMembers { get; set; }

        public MulticastAttributes AttributeTargetMemberAttributes { get; set; }

        public MulticastAttributes AttributeTargetExternalMemberAttributes { get; set; }

        public string AttributeTargetParameters { get; set; }

        public MulticastAttributes AttributeTargetParameterAttributes { get; set; }

        public bool AttributeExclude { get; set; }

        public int AttributePriority { get; set; }

        public bool AttributeReplace { get; set; }

        public MulticastInheritance AttributeInheritance { get; set; }

        [Obsolete( "Do not use this property in customer code.", true )]

        public long AttributeId { get; set; }
    }
}
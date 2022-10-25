using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Custom attribute that determines the usage of a <see cref = "MulticastAttribute" />.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = false, Inherited = true )]
    public sealed class MulticastAttributeUsageAttribute : Attribute
    {
        /// <summary>
        ///   Initializes a new <see cref = "MulticastAttributeUsageAttribute" />.
        /// </summary>
        /// <param name = "validOn">Kinds of targets that instances of the related <see cref = "MulticastAttribute" />
        ///   apply to.</param>
        public MulticastAttributeUsageAttribute( MulticastTargets validOn )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new <see cref="MulticastAttributeUsageAttribute"/>.
        /// </summary>
        public MulticastAttributeUsageAttribute() { }

        /// <summary>
        ///   Gets the kinds of targets that instances of the related <see cref = "MulticastAttribute" />
        ///   apply to.
        /// </summary>
        public MulticastTargets ValidOn { get; }

        /// <summary>
        ///   Determines whether many instances of the custom attribute are allowed on a single declaration.
        /// </summary>
        public bool AllowMultiple { get; set; }

        /// <summary>
        ///   Determines whether the custom attribute in inherited along the lines of inheritance
        ///   of the target element.
        /// </summary>
        /// <seealso cref = "MulticastAttribute.AttributeInheritance" />
        public MulticastInheritance Inheritance { get; set; }

        /// <summary>
        ///   Determines whether this attribute can be applied to declaration of external assemblies
        ///   (i.e. to other assemblies than the one in which the custom attribute is instantiated).
        /// </summary>
        public bool AllowExternalAssemblies { get; set; }

        /// <summary>
        ///   Determines whether the custom attribute should be persisted in metadata, so that
        ///   it would be available for <c>System.Reflection</c>.
        /// </summary>
        public bool PersistMetaData { get; set; }

        /// <summary>
        ///   Gets or sets the attributes of the members (fields or methods) to which
        ///   the custom attribute can be applied.
        /// </summary>
        public MulticastAttributes TargetMemberAttributes { get; set; }

        /// <summary>
        ///   Gets or sets the attributes of the members (fields or methods) to which
        ///   the custom attribute can be applied, when the members are external to
        ///   the current module.
        /// </summary>
        public MulticastAttributes TargetExternalMemberAttributes { get; set; }

        /// <summary>
        ///   Gets or sets the attributes of the parameter to which
        ///   the custom attribute can be applied.
        /// </summary>
        public MulticastAttributes TargetParameterAttributes { get; set; }

        /// <summary>
        ///   Gets or sets the attributes of the types to which
        ///   the custom attribute can be applied. Visibility, scope (<see cref="MulticastAttributes.Instance"/> or <see cref="MulticastAttributes.Static"/>)
        ///   and generation are the only categories that are taken into account; attributes of other categories are ignored. If the custom attribute relates to
        ///   fields or methods, this property specifies which attributes of the declaring type are acceptable.
        /// </summary>
        public MulticastAttributes TargetTypeAttributes { get; set; }

        /// <summary>
        ///   Gets or sets the attributes of the types to which
        ///   the custom attribute can be applied, when the type is external to
        ///   the current module. If the custom attribute relates to
        ///   fields or methods, this property specifies which attributes
        ///   of the declaring type are acceptable.
        /// </summary>
        public MulticastAttributes TargetExternalTypeAttributes { get; set; }
    }
}
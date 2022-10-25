using System;
using PostSharp.Aspects.Serialization;
using PostSharp.Serialization;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Custom attribute that can be applied to multiple elements
    /// using wildcards.
    /// </summary>
    /// <remarks>
    /// <para>Each class derived from <see cref="MulticastAttribute"/>
    /// should be decorated with an instance of <see cref="MulticastAttributeUsageAttribute"/>.
    /// </para>
    /// <para>
    /// Note to implementors: The properties of this class that start with the word 'Attribute' only have an effect if they are
    /// set at the point where the attribute is used (in brackets). Setting them in the constructor of your subclass has no effect.
    /// </para>
    /// <para>
    /// Multicasting is performed by the <b>MulticastAttributeTask</b>, which should be
    /// included in the project. After multicasting, custom attribute instances are
    /// available on the <b>CustomAttributeDictionaryTask</b> class.
    /// </para>
    /// </remarks>
    [Serializable]
    [Serializer( null )]
    public abstract class MulticastAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the kind of elements to which this custom attributes applies.
        /// </summary>
        [AspectSerializerIgnore]
        public MulticastTargets AttributeTargetElements { get; set; }

        /// <summary>
        /// Gets or sets the assemblies to which the current attribute apply.
        /// </summary>
        /// <value>
        /// Wildcard or regular expression specifying to which assemblies
        /// this instance applies, or <c>null</c> if this instance applies
        /// only to elements of the current assembly. Wildcard expressions should
        /// start with the <c>regex:</c> prefix.
        /// </value>
        /// <remarks>
        /// When this property is not specified or is <c>null</c>, the current
        /// attribute is multicasted only in the current assembly. Otherwise, it
        /// is multicasted also to external assemblies, i.e. to declarations that
        /// are <i>referenced</i> by the current assembly.
        /// </remarks>
        [AspectSerializerIgnore]
        public string AttributeTargetAssemblies { get; set; }

        /// <summary>
        /// Gets or sets the expression specifying to which types
        /// this instance applies.
        /// </summary>
        /// <value>
        /// A wildcard or regular expression specifying to which types
        /// this instance applies, or <c>null</c> this instance
        /// applies either to all types. Regular expressions should
        /// start with the <c>regex:</c> prefix.
        /// </value>
        /// <remarks>
        /// <para>Ignored if the <see cref="AttributeTargetElements"/> are only the module and/or the assembly.
        /// </para>
        /// <para>Unless you use a wildcard or a regex, you must specify the fully qualified name of the type.</para>
        /// <para>Nested types are delimited by a plus sign (<c>+</c>) in place of a dot (<c>.</c>).</para>
        /// <para>If the type is generic, add a backtick and its type arity at the end.</para>
        /// <para>Examples:
        /// <list type="bullet">
        ///    <item>Namespace.OuterType`1+NestedType`2</item>
        ///    <item>regex:Namespac.*Nested.*</item>
        /// </list>
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public string AttributeTargetTypes { get; set; }

        /// <summary>
        /// Gets or sets the attributes of types to which this attribute applies. Visibility, scope (<see cref="MulticastAttributes.Instance"/> or <see cref="MulticastAttributes.Static"/>)
        ///   and generation are the only categories that are taken into account; attributes of other categories are ignored.
        /// </summary>
        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetTypeAttributes { get; set; }

        /// <summary>
        /// Gets or sets the visibilities of types to which this attribute applies,
        /// when this type is external to the current module.
        /// </summary>
        /// <remarks>
        /// On type-level, the only meaningful enumeration values are related to visibility.
        /// </remarks>
        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetExternalTypeAttributes { get; set; }

        /// <summary>
        /// Gets or sets the expression specifying to which members 
        /// this instance applies.
        /// </summary>
        /// <value>
        /// A wildcard or regular expression specifying to which members
        /// this instance applies, or <c>null</c> this instance
        /// applies either to all members whose kind is given in <see cref="AttributeTargetElements"/>.
        /// Regular expressions should start with the <c>regex:</c> prefix.
        /// </value>
        /// <remarks>
        /// <para>Ignored if the only <see cref="AttributeTargetElements"/> are only types.
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public string AttributeTargetMembers { get; set; }

        /// <summary>
        /// Gets or sets the visibilities, scopes, virtualities, and other characteristics 
        ///  of members to which this attribute applies.
        /// </summary>
        /// <remarks>
        /// <para>Ignored if the <see cref="AttributeTargetElements"/> are only the module, the assembly,
        /// and/or types.
        /// </para>
        /// <para>
        /// The <see cref="MulticastAttributes"/> enumeration is a multi-part flag: there is one
        /// part for visibility, one for scope, one for virtuality, and so on.
        /// If you specify one part, it will override the values defined on the custom attribute definition.
        /// If you do not specify it, the values defined on the custom attribute definition will be inherited.
        /// Note that custom attributes may apply restrictions on these attributes. For instance, 
        /// a custom attribute may not be valid on abstract methods. You are obviously not allowed
        /// to 'enlarge' the set of possible targets.
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetMemberAttributes { get; set; }

        /// <summary>
        /// Gets or sets the visibilities, scopes, virtualities, and implementation
        ///  of members to which this attribute applies, when the member is external to the current module.
        /// </summary>
        /// <remarks>
        /// <para>Ignored if the <see cref="AttributeTargetElements"/> are only the module, the assembly,
        /// and/or types.
        /// </para>
        /// <para>
        /// The <see cref="MulticastAttributes"/> enumeration is a multi-part flag: there is one
        /// part for visibility, one for scope, one for virtuality, and one for implementation.
        /// If you specify one part, it will override the values defined on the custom attribute definition.
        /// If you do not specify it, the values defined on the custom attribute definition will be inherited.
        /// Note that custom attributes may apply restrictions on these attributes. For instance, 
        /// a custom attribute may not be valid on abstract methods. You are obviously not allowed
        /// to 'enlarge' the set of possible targets.
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetExternalMemberAttributes { get; set; }

        /// <summary>
        /// Gets or sets the expression specifying to which parameters 
        /// this instance applies.
        /// </summary>
        /// <value>
        /// A wildcard or regular expression specifying to which parameters
        /// this instance applies, or <c>null</c> this instance
        /// applies either to all members whose kind is given in <see cref="AttributeTargetElements"/>.
        /// Wildcard expressions should
        /// start with the <c>regex:</c> prefix.
        /// </value>
        /// <remarks>
        /// <para>Ignored if the only <see cref="AttributeTargetElements"/> are only types.
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public string AttributeTargetParameters { get; set; }

        /// <summary>
        /// Gets or sets the passing style (by value, <b>out</b> or <b>ref</b>)
        ///  of parameters to which this attribute applies.
        /// </summary>
        /// <remarks>
        /// <para>Ignored if the <see cref="AttributeTargetElements"/> do not include parameters.
        /// </para>
        /// </remarks>
        [AspectSerializerIgnore]
        public MulticastAttributes AttributeTargetParameterAttributes { get; set; }

        /// <summary>
        /// If true, indicates that this attribute <i>removes</i> all other instances of the
        /// same attribute type from the set of elements defined by the current instance.
        /// </summary>
        [AspectSerializerIgnore]
        public bool AttributeExclude { get; set; }

        /// <summary>
        /// Gets or sets the priority of the current attribute in case that multiple 
        /// instances are defined on the same element (lower values are processed before).
        /// </summary>
        /// <remarks>
        /// You should use only 16-bit values in user code. Top 16 bits are reserved for the system.
        /// </remarks>
        [AspectSerializerIgnore]
        public int AttributePriority { get; set; }

        /// <summary>
        /// Determines whether this attribute replaces other attributes found on the
        /// target declarations.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current instance will replace previous ones, or <c>false</c>
        /// if it will be added to previous instances.
        /// </value>
        [AspectSerializerIgnore]
        public bool AttributeReplace { get; set; }

        /// <summary>
        /// Determines whether this attribute is inherited
        /// </summary>
        /// <remarks>
        /// <para>If this property is not set to <c>MulticastInheritance.None</c>,
        /// a copy of this attribute will be propagated
        /// along the lines of inheritance of the target element:</para>
        /// <list type="bullet">
        /// <item>On <b>classes</b>: all classed derived from that class.</item>
        /// <item>On <b>interfaces</b>: all classes implementing this interface.</item>
        /// <item>On <b>virtual, abstract or interface methods</b>: all methods overriding 
        /// or implementing this method.</item>
        /// <item>On <b>parameters</b> or <b>return value</b> of virtual, abstract or interface methods:
        /// corresponding parameter or return value on all methods or overriding or implementing the
        /// parent method of the target parameter or return value.</item>
        /// </list>
        /// </remarks>
        [AspectSerializerIgnore]
        public MulticastInheritance AttributeInheritance { get; set; }

        // TODO: Used in compiler.
        /// <exclude />
        [Obsolete( "Do not use this property in customer code.", true )]
        [AspectSerializerIgnore]
        public long AttributeId { get; set; }
    }
}
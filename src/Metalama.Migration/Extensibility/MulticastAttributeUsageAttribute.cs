// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

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
        ///   Kinds of targets that instances of the related <see cref = "MulticastAttribute" />
        ///   apply to.
        /// </summary>
        private MulticastTargets validOn;

        private BoolWithDefault allowExternalAssemblies;
        private BoolWithDefault allowMultiple;


        private MulticastInheritance inheritance;
        private bool isInheritanceSpecified;

        private BoolWithDefault persistMetaData;

        private MulticastAttributes targetMemberAttributes = MulticastAttributes.All;
        private bool isTargetMemberAttributesSpecified;

        private MulticastAttributes targetExternalMemberAttributes = MulticastAttributes.All;
        private bool isTargetExternalMemberAttributesSpecified;

        private MulticastAttributes targetParameterAttributes = MulticastAttributes.All;
        private bool isTargetParameterAttributesSpecified;


        private MulticastAttributes targetTypeAttributes = MulticastAttributes.All;
        private bool isTargetTypeAttributesSpecified;

        private MulticastAttributes targetExternalTypeAttributes = MulticastAttributes.All;
        private bool isTargetExternalTypeAttributesSpecified;
        
        /// <summary>
        ///   Initializes a new <see cref = "MulticastAttributeUsageAttribute" />.
        /// </summary>
        /// <param name = "validOn">Kinds of targets that instances of the related <see cref = "MulticastAttribute" />
        ///   apply to.</param>
        public MulticastAttributeUsageAttribute( MulticastTargets validOn )
        {
            this.validOn = validOn;
        }

        /// <summary>
        /// Initializes a new <see cref="MulticastAttributeUsageAttribute"/>.
        /// </summary>
        public MulticastAttributeUsageAttribute()
        {
        }

        /// <summary>
        ///   Gets the kinds of targets that instances of the related <see cref = "MulticastAttribute" />
        ///   apply to.
        /// </summary>
        public MulticastTargets ValidOn
        {
            get { return this.validOn; }
            internal set { this.validOn = value; }
        }

        /// <summary>
        ///   Determines whether many instances of the custom attribute are allowed on a single declaration.
        /// </summary>
        public bool AllowMultiple
        {
            get { return this.allowMultiple == BoolWithDefault.True; }
            set { this.allowMultiple = value ? BoolWithDefault.True : BoolWithDefault.False; }
        }

        internal bool IsAllowMultipleSpecified
        {
            get { return this.allowMultiple != BoolWithDefault.Default; }
        }

        /// <summary>
        ///   Determines whether the custom attribute in inherited along the lines of inheritance
        ///   of the target element.
        /// </summary>
        /// <seealso cref = "MulticastAttribute.AttributeInheritance" />
        public MulticastInheritance Inheritance
        {
            get { return this.inheritance; }
            set
            {
                this.inheritance = value;
                this.isInheritanceSpecified = true;
            }
        }

        internal bool IsInheritanceSpecified
        {
            get { return this.isInheritanceSpecified; }
        }

        /// <summary>
        ///   Determines whether this attribute can be applied to declaration of external assemblies
        ///   (i.e. to other assemblies than the one in which the custom attribute is instantiated).
        /// </summary>
        public bool AllowExternalAssemblies
        {
            get { return this.allowExternalAssemblies == BoolWithDefault.True; }
            set { this.allowExternalAssemblies = value ? BoolWithDefault.True : BoolWithDefault.False; }
        }

        internal bool IsAllowExternalAssembliesSpecified
        {
            get { return this.allowExternalAssemblies != BoolWithDefault.Default; }
        }

        /// <summary>
        ///   Determines whether the custom attribute should be persisted in metadata, so that
        ///   it would be available for <c>System.Reflection</c>.
        /// </summary>
        public bool PersistMetaData
        {
            get { return this.persistMetaData == BoolWithDefault.True; }
            set { this.persistMetaData = value ? BoolWithDefault.True : BoolWithDefault.False; }
        }

        internal bool IsPersistMetaDataSpecified
        {
            get { return this.persistMetaData != BoolWithDefault.Default; }
        }

        /// <summary>
        ///   Gets or sets the attributes of the members (fields or methods) to which
        ///   the custom attribute can be applied.
        /// </summary>
        public MulticastAttributes TargetMemberAttributes
        {
            get { return this.targetMemberAttributes; }
            set
            {
                this.targetMemberAttributes = value;
                this.isTargetMemberAttributesSpecified = true;
            }
        }

        internal bool IsTargetMemberAttributesSpecified
        {
            get { return this.isTargetMemberAttributesSpecified; }
        }

        /// <summary>
        ///   Gets or sets the attributes of the members (fields or methods) to which
        ///   the custom attribute can be applied, when the members are external to
        ///   the current module.
        /// </summary>
        public MulticastAttributes TargetExternalMemberAttributes
        {
            get { return this.targetExternalMemberAttributes; }
            set
            {
                this.targetExternalMemberAttributes = value;
                this.isTargetExternalMemberAttributesSpecified = true;
            }
        }

        internal bool IsTargetExternalMemberAttributesSpecified
        {
            get { return this.isTargetExternalMemberAttributesSpecified; }
        }

        /// <summary>
        ///   Gets or sets the attributes of the parameter to which
        ///   the custom attribute can be applied.
        /// </summary>
        public MulticastAttributes TargetParameterAttributes
        {
            get { return this.targetMemberAttributes; }
            set
            {
                this.targetParameterAttributes = value;
                this.isTargetParameterAttributesSpecified = true;
            }
        }

        internal bool IsTargetParameterAttributesSpecified
        {
            get { return this.isTargetParameterAttributesSpecified; }
        }

        /// <summary>
        ///   Gets or sets the attributes of the types to which
        ///   the custom attribute can be applied. Visibility, scope (<see cref="MulticastAttributes.Instance"/> or <see cref="MulticastAttributes.Static"/>)
        ///   and generation are the only categories that are taken into account; attributes of other categories are ignored. If the custom attribute relates to
        ///   fields or methods, this property specifies which attributes of the declaring type are acceptable.
        /// </summary>
        public MulticastAttributes TargetTypeAttributes
        {
            get { return this.targetTypeAttributes; }
            set
            {
                this.targetTypeAttributes = value;
                this.isTargetTypeAttributesSpecified = true;
            }
        }

        internal bool IsTargetTypeAttributesSpecified
        {
            get { return this.isTargetTypeAttributesSpecified; }
        }

        /// <summary>
        ///   Gets or sets the attributes of the types to which
        ///   the custom attribute can be applied, when the type is external to
        ///   the current module. If the custom attribute relates to
        ///   fields or methods, this property specifies which attributes
        ///   of the declaring type are acceptable.
        /// </summary>
        public MulticastAttributes TargetExternalTypeAttributes
        {
            get { return this.targetExternalTypeAttributes; }
            set
            {
                this.targetExternalTypeAttributes = value;
                this.isTargetExternalTypeAttributesSpecified = true;
            }
        }

        internal bool IsTargetExternalTypeAttributesSpecified
        {
            get { return this.isTargetExternalTypeAttributesSpecified; }
        }

        internal MulticastAttributeUsageAttribute Clone()
        {
            MulticastAttributeUsageAttribute clone = new MulticastAttributeUsageAttribute( this.validOn )
                                                     {
                                                         persistMetaData = this.persistMetaData,
                                                         allowExternalAssemblies = this.allowExternalAssemblies,
                                                         allowMultiple = this.allowMultiple,
                                                         targetMemberAttributes = this.targetMemberAttributes,
                                                         isTargetMemberAttributesSpecified =
                                                             this.isTargetMemberAttributesSpecified,
                                                         targetParameterAttributes = this.targetParameterAttributes,
                                                         isTargetParameterAttributesSpecified =
                                                             this.isTargetParameterAttributesSpecified
                                                     };
            return clone;
        }

        internal static MulticastAttributeUsageAttribute GetMaximumValue()
        {
            MulticastAttributeUsageAttribute attribute = new MulticastAttributeUsageAttribute( MulticastTargets.All )
                                                         {
                                                             AllowExternalAssemblies = true,
                                                             AllowMultiple = true,
                                                             TargetMemberAttributes = MulticastAttributes.All,
                                                             TargetTypeAttributes = MulticastAttributes.All
                                                         };

            return attribute;
        }
    }
}

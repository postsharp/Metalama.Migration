// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Instance of a custom attribute on a target declaration.
    /// </summary>
    public sealed class CustomAttributeInstance
    {
        private ObjectConstruction customAttributeData;
        private Attribute customAttributeObject;

        internal CustomAttributeInstance(object target, object annotation)
        {
            this.Target = target;
            this.Annotation = annotation;
        }

        /// <summary>
        ///   Gets the <see cref = "ObjectConstruction" /> (including given constructor
        ///   arguments and named arguments) used to construct
        ///   the <see cref = "Attribute" />.
        /// </summary>
        public ObjectConstruction Construction
        {
            get
            {
                if ( this.customAttributeData == null )
                {
                    this.customAttributeData = ServiceCache.Current.AnnotationRepositoryService.CreateCustomAttributeData( this );
                }

                return this.customAttributeData;
            }
        }


        /// <summary>
        ///   Gets the custom attribute.
        /// </summary>
        public Attribute Attribute
        {
            get
            {
                if ( this.customAttributeObject == null )
                {
                    this.customAttributeObject = ServiceCache.Current.AnnotationRepositoryService.CreateCustomAttributeObject( this );
                }

                return this.customAttributeObject;
            }
        }

        /// <summary>
        ///   Gets the declaration on which the custom attribute is defined.
        /// </summary>
        /// <value>
        ///   A reflection object: <see cref = "Assembly" />, <see cref = "Type" />, <see cref = "MethodInfo" />,
        ///   <see cref = "ConstructorInfo" />, <see cref = "ParameterInfo" />, <see cref = "PropertyInfo" />,
        ///   <see cref = "EventInfo" />, <see cref = "FieldInfo" />.
        /// </value>
        public object Target { get; private set; }
        internal object Annotation { get; private set; }
    }

}
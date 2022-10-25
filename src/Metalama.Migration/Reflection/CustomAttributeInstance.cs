using System;
using System.Reflection;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Instance of a custom attribute on a target declaration.
    /// </summary>
    public sealed class CustomAttributeInstance
    {
        internal CustomAttributeInstance( object target, object annotation )
        {
            Target = target;
            Annotation = annotation;
        }

        /// <summary>
        ///   Gets the <see cref = "ObjectConstruction" /> (including given constructor
        ///   arguments and named arguments) used to construct
        ///   the <see cref = "Attribute" />.
        /// </summary>
        public ObjectConstruction Construction { get; }

        /// <summary>
        ///   Gets the custom attribute.
        /// </summary>
        public Attribute Attribute { get; }

        /// <summary>
        ///   Gets the declaration on which the custom attribute is defined.
        /// </summary>
        /// <value>
        ///   A reflection object: <see cref = "Assembly" />, <see cref = "Type" />, <see cref = "MethodInfo" />,
        ///   <see cref = "ConstructorInfo" />, <see cref = "ParameterInfo" />, <see cref = "PropertyInfo" />,
        ///   <see cref = "EventInfo" />, <see cref = "FieldInfo" />.
        /// </value>
        public object Target;

        internal object Annotation { get; }
    }
}
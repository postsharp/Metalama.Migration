using System;

namespace PostSharp.Reflection
{
    public sealed class CustomAttributeInstance
    {
        internal CustomAttributeInstance( object target, object annotation )
        {
            Target = target;
            Annotation = annotation;
        }

        public ObjectConstruction Construction { get; }

        public Attribute Attribute { get; }

        public object Target;

        internal object Annotation { get; }
    }
}
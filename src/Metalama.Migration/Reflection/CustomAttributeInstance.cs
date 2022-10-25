using System;
using Metalama.Framework.Code;

namespace PostSharp.Reflection
{
    /// <summary>
    /// In Metalama, use <see cref="IAttributeData"/>.
    /// </summary>
    public sealed class CustomAttributeInstance
    {
        public ObjectConstruction Construction { get; }

        public Attribute Attribute { get; }

        public object Target;

        internal object Annotation { get; }
    }
}
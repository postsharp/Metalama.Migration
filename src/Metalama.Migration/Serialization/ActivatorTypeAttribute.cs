using System;

namespace PostSharp.Serialization
{
    [AttributeUsage( AttributeTargets.Assembly )]
    public sealed class ActivatorTypeAttribute : Attribute
    {
        public ActivatorTypeAttribute( Type activatorType )
        {
            ActivatorType = activatorType;
        }

        public Type ActivatorType { get; }
    }
}
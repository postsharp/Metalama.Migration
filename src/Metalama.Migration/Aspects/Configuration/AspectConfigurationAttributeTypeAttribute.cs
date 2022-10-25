using System;

namespace PostSharp.Aspects.Configuration
{
    [AttributeUsage( AttributeTargets.Class )]
    public sealed class AspectConfigurationAttributeTypeAttribute : Attribute
    {
        public AspectConfigurationAttributeTypeAttribute( Type type )
        {
            AttributeType = type;
        }

        public Type AttributeType { get; }
    }
}
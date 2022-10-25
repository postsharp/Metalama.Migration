using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
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
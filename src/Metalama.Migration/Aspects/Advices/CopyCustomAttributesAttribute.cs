using System;

namespace PostSharp.Aspects.Advices
{
    /// <summary>
    /// In Metalama, all custom attributes except Metalama ones are copied from the template to the introduced declaration.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Event | AttributeTargets.Property | AttributeTargets.Method )]
    public sealed class CopyCustomAttributesAttribute : Advice
    {
        public CopyCustomAttributesAttribute( Type type )
        {
            Types = new[] { type };
        }

        public CopyCustomAttributesAttribute( params Type[] types )
        {
            Types = types;
        }

        public CustomAttributeOverrideAction OverrideAction { get; set; }

        public Type[] Types { get; }
    }
}
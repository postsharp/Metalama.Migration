using System;

namespace PostSharp.Extensibility
{
    // TODO: redesign ImplementationBoundAttributeAttribute stuff.

    [AttributeUsage( AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class ImplementationBoundAttributeAttribute : Attribute
    {
        public ImplementationBoundAttributeAttribute( Type attributeType )
        {
            throw new NotImplementedException();
        }

        public Type AttributeType { get; }
    }
}
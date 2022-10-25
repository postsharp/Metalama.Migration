using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// There is no equivalent in Metalama. This logic is currently hard-coded.
    /// </summary>
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
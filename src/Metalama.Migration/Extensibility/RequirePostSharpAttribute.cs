using System;

namespace PostSharp.Extensibility
{
    [AttributeUsage( AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class RequirePostSharpAttribute : Attribute
    {
        public RequirePostSharpAttribute( string plugIn, string task )
        {
            throw new NotImplementedException();
        }

        public RequirePostSharpAttribute( string plugIn )
        {
            throw new NotImplementedException();
        }

        public RequirePostSharpAttribute( Type serviceType )
        {
            ServiceType = serviceType;
        }

        public string PlugIn { get; }

        public string Task { get; }

        public Type ServiceType { get; }

        public bool AssemblyReferenceOnly { get; set; }

        public bool AnyTypeReference { get; set; }
    }
}
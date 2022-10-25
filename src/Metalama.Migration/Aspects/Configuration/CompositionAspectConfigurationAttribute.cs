using System;
using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public sealed class CompositionAspectConfigurationAttribute : AspectConfigurationAttribute
    {
        public string[] PublicInterfaces { get; set; }

        public string[] ProtectedInterfaces { get; set; }

        public InterfaceOverrideAction OverrideAction { get; set; }

        public InterfaceOverrideAction AncestorOverrideAction { get; set; }

        public bool NonSerializedImplementation { get; set; }

        [Obsolete( "This property has no effect and will be removed in a future version." )]
        public bool GenerateImplementationAccessor { get; set; }

        protected override AspectConfiguration CreateAspectConfiguration()
        {
            throw new NotImplementedException();
        }
    }
}
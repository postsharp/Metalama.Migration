using System;
using PostSharp.Aspects.Advices;

namespace PostSharp.Aspects.Configuration
{
    public sealed class CompositionAspectConfiguration : AspectConfiguration
    {
#pragma warning disable CA1819 // Properties should not return arrays (TODO)

        public TypeIdentity[] PublicInterfaces { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays (TODO)

        public InterfaceOverrideAction? OverrideAction { get; set; }

        public InterfaceOverrideAction? AncestorOverrideAction { get; set; }

        public bool? NonSerializedImplementation { get; set; }

        [Obsolete( "This property has no effect and will be removed in a future version." )]
        public bool? GenerateImplementationAccessor { get; set; }
    }
}
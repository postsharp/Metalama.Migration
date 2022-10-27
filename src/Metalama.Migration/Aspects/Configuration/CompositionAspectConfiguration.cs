// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using PostSharp.Aspects.Advices;
using System;

namespace PostSharp.Aspects.Configuration
{
    /// <summary>
    /// There is no aspect configuration in Metalama.
    /// </summary>
    public sealed class CompositionAspectConfiguration : AspectConfiguration
    {
        public TypeIdentity[] PublicInterfaces { get; set; }

        public InterfaceOverrideAction? OverrideAction { get; set; }

        public InterfaceOverrideAction? AncestorOverrideAction { get; set; }

        public bool? NonSerializedImplementation { get; set; }

        [Obsolete( "This property has no effect and will be removed in a future version." )]
        public bool? GenerateImplementationAccessor { get; set; }
    }
}
// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

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
            this.Types = new[] { type };
        }

        public CopyCustomAttributesAttribute( params Type[] types )
        {
            this.Types = types;
        }

        public CustomAttributeOverrideAction OverrideAction { get; set; }

        public Type[] Types { get; }
    }
}
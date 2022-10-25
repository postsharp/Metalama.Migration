// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [AttributeUsage(
        AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.ReturnValue )]
    public sealed class HasInheritedAttributeAttribute : Attribute
    {
        public HasInheritedAttributeAttribute() { }

        // TODO: Used in compiler.

        [Obsolete( "Do not use this custom attribute in user code.", false )]
        public HasInheritedAttributeAttribute( long[] ids ) { }
    }
}
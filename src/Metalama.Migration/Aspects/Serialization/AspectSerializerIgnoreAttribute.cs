// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Aspects.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    internal sealed class AspectSerializerIgnoreAttribute : Attribute
    {
    }
}
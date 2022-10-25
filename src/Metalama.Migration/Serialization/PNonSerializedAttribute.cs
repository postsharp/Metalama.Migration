// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Custom attribute that, when applied to a field of a class annotated with <see cref="PSerializableAttribute"/>,
    /// specifies that this field should not be serialized.
    /// </summary>
    [AttributeUsage( AttributeTargets.Field )]
    public sealed class PNonSerializedAttribute : Attribute
    {

    }
}

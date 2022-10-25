// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Custom attribute that, when applied to a type, causes PostSharp to generate a serializer for use by the <see cref="PortableFormatter"/>.
    /// </summary>
    /// <remarks>
    /// <para>Fields that should not be serialized must be annotated with <see cref="PNonSerializedAttribute"/>.</para>
    ///     <para>This class inherits from <see cref="MulticastAttribute"/>, so it is possible to use multicasting to
    /// add this aspect to several classes using a single line, or to add this aspect to derived classes through inheritance.</para>
    /// </remarks>
    /// <seealso cref="PortableFormatter"/>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct |  AttributeTargets.Assembly)]
    [MulticastAttributeUsage(MulticastTargets.Class | MulticastTargets.Struct)]
    [RequirePostSharp(null, "PortableSerializer")]
    [LinesOfCodeAvoided(0)]
    public sealed class PSerializableAttribute : MulticastAttribute, IAspect
    {
      
    }
}

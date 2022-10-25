using System;
using Metalama.Framework.Serialization;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace PostSharp.Serialization
{
    /// <summary>
    /// In Metalama, make the type implement the <see cref="ILamaSerializable"/> interface.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly )]
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Struct )]
    [RequirePostSharp( null, "PortableSerializer" )]
    [LinesOfCodeAvoided( 0 )]
    public sealed class PSerializableAttribute : MulticastAttribute, IAspect { }
}
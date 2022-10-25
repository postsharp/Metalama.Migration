using System;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace PostSharp.Serialization
{
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Assembly )]
    [MulticastAttributeUsage( MulticastTargets.Class | MulticastTargets.Struct )]
    [RequirePostSharp( null, "PortableSerializer" )]
    [LinesOfCodeAvoided( 0 )]
    public sealed class PSerializableAttribute : MulticastAttribute, IAspect { }
}
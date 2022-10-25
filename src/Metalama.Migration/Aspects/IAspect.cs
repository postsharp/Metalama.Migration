using PostSharp.Extensibility;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    [RequirePostSharp( null, "AspectWeaver" )]
    public interface IAspect { }
}
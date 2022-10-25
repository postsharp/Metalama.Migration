using PostSharp.Aspects.Configuration;
using PostSharp.Extensibility;

#pragma warning disable CA1040 // Avoid empty interfaces

namespace PostSharp.Aspects
{
    /// <summary>
    ///   Base interface for run-time semantics of all aspects.
    /// </summary>
    /// <seealso cref = "IAspectBuildSemantics" />
    /// <seealso cref = "AspectConfiguration" />
    /// <seealso cref = "Aspect" />
    [RequirePostSharp( null, "AspectWeaver" )]
    public interface IAspect { }
}
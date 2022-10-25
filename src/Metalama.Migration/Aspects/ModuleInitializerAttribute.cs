using System;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
    /// <summary>
    /// Not supported in Metalama, but it is now supported by C# itself.
    /// </summary>
    [AttributeUsage( AttributeTargets.Method )]
    [RequirePostSharp( null, "ModuleInitializer" )]
    public sealed class ModuleInitializerAttribute : Attribute
    {
        public ModuleInitializerAttribute( int order )
        {
            Order = order;
        }

        public int Order { get; }
    }
}
using System;
using PostSharp.Extensibility;

namespace PostSharp.Aspects
{
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
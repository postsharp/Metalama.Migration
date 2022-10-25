using System.Diagnostics;
using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    [DebuggerStepThrough]
    [DebuggerNonUserCode]
    public sealed class AspectInstance : AspectSpecification
    {
        public AspectInstance( object targetElement, IAspect aspect ) { }

        public AspectInstance( object targetElement, IAspect aspect, AspectConfiguration aspectConfiguration ) { }

        public AspectInstance( object targetElement, ObjectConstruction aspectConstruction ) { }

        public AspectInstance(
            object targetElement,
            ObjectConstruction aspectConstruction,
            AspectConfiguration aspectConfiguration ) { }

        public object TargetElement { get; }

        public bool RepresentAsStandalone { get; set; }
    }
}
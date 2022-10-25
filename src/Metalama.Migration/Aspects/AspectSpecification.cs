using PostSharp.Aspects.Configuration;
using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent to this class in Metalama.
    /// </summary>
    public class AspectSpecification
    {
        public AspectConfiguration AspectConfiguration { get; }

        public ObjectConstruction AspectConstruction { get; }

        public IAspect Aspect { get; }

        public string AspectAssemblyQualifiedTypeName { get; }

        public string AspectTypeName { get; }
    }
}
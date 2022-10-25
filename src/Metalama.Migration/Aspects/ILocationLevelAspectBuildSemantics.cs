using PostSharp.Reflection;

namespace PostSharp.Aspects
{
    public interface ILocationLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        void CompileTimeInitialize( LocationInfo targetLocation, AspectInfo aspectInfo );
    }
}
using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IMethodLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo );
    }
}
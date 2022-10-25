using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IAssemblyLevelAspectBuildSemantics : IAspect
    {
        void CompileTimeInitialize( Assembly assembly, AspectInfo aspectInfo );
    }
}
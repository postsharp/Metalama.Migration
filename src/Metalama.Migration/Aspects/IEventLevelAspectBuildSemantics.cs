using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IEventLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        void CompileTimeInitialize( EventInfo targetEvent, AspectInfo aspectInfo );
    }
}
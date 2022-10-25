using System;

namespace PostSharp.Aspects
{
    public interface ITypeLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        void CompileTimeInitialize( Type type, AspectInfo aspectInfo );
    }
}
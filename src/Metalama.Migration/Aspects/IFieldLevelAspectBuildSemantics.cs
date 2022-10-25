using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IFieldLevelAspectBuildSemantics : IAspectBuildSemantics
    {
        void CompileTimeInitialize( FieldInfo field, AspectInfo aspectInfo );
    }
}
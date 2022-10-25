using System.Reflection;

namespace PostSharp.Aspects
{
    public interface IMethodLevelAspect : IAspect
    {
        void RuntimeInitialize( MethodBase method );
    }
}
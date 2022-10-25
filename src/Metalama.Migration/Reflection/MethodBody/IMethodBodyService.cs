using System.Reflection;
using PostSharp.Extensibility;

namespace PostSharp.Reflection.MethodBody
{
    public interface IMethodBodyService : IService
    {
        IMethodBody GetMethodBody( MethodBase method, MethodBodyAbstractionLevel abstractionLevel );
    }
}
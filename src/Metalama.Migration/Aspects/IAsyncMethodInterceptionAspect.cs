using System.Threading.Tasks;

namespace PostSharp.Aspects
{
    public interface IAsyncMethodInterceptionAspect : IMethodInterceptionAspect
    {
        Task OnInvokeAsync( MethodInterceptionArgs args );
    }
}
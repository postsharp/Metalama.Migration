namespace PostSharp.Aspects
{
    public interface IOnExceptionAspect : IMethodLevelAspect
    {
        void OnException( MethodExecutionArgs args );
    }
}
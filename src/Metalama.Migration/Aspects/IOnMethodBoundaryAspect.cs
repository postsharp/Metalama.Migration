namespace PostSharp.Aspects
{
    public interface IOnMethodBoundaryAspect : IMethodLevelAspect
    {
        void OnEntry( MethodExecutionArgs args );

        void OnExit( MethodExecutionArgs args );

        void OnSuccess( MethodExecutionArgs args );

        void OnException( MethodExecutionArgs args );
    }
}
namespace PostSharp.Aspects
{
    public interface IOnStateMachineBoundaryAspect : IOnMethodBoundaryAspect
    {
        void OnResume( MethodExecutionArgs args );

        void OnYield( MethodExecutionArgs args );
    }
}
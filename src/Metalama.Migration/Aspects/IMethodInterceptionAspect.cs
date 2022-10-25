namespace PostSharp.Aspects
{
    public interface IMethodInterceptionAspect : IMethodLevelAspect
    {
        void OnInvoke( MethodInterceptionArgs args );
    }
}
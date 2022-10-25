namespace PostSharp.Aspects
{
    public interface ICompositionAspect : ITypeLevelAspect
    {
        object CreateImplementationObject( AdviceArgs args );
    }
}
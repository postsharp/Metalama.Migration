namespace PostSharp.Aspects
{
    public interface ICloneAwareAspect : IInstanceScopedAspect
    {
        void OnCloned( ICloneAwareAspect source );
    }
}
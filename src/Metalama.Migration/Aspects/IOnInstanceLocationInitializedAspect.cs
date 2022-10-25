namespace PostSharp.Aspects
{
    public interface IOnInstanceLocationInitializedAspect : ILocationLevelAspect
    {
        void OnInstanceLocationInitialized( LocationInitializationArgs args );
    }
}
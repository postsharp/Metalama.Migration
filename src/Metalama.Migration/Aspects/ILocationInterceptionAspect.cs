namespace PostSharp.Aspects
{
    public interface ILocationInterceptionAspect : ILocationLevelAspect
    {
        void OnGetValue( LocationInterceptionArgs args );

        void OnSetValue( LocationInterceptionArgs args );
    }
}
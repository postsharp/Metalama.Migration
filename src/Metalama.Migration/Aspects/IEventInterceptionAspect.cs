namespace PostSharp.Aspects
{
    public interface IEventInterceptionAspect : IEventLevelAspect
    {
        void OnAddHandler( EventInterceptionArgs args );

        void OnRemoveHandler( EventInterceptionArgs args );

        void OnInvokeHandler( EventInterceptionArgs args );
    }
}
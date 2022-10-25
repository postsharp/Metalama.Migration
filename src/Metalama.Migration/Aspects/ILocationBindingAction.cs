namespace PostSharp.Aspects
{
    public interface ILocationBindingAction<TPayload>
    {
        void Execute<TValue>( ILocationBinding<TValue> binding, ref TPayload payload );
    }
}
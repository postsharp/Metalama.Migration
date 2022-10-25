namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    public interface ILocationBindingAction<TPayload>
    {
        void Execute<TValue>( ILocationBinding<TValue> binding, ref TPayload payload );
    }
}
namespace PostSharp.Aspects
{
    /// <summary>
    /// There is no equivalent in Metalama.
    /// </summary>
    public interface ILocationInterceptionArgsAction<TPayload>
    {
        void Execute<TValue>( ILocationInterceptionArgs<TValue> args, ref TPayload payload );
    }
}
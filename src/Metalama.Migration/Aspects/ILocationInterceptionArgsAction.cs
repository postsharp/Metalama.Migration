namespace PostSharp.Aspects
{
    public interface ILocationInterceptionArgsAction<TPayload>
    {
        void Execute<TValue>( ILocationInterceptionArgs<TValue> args, ref TPayload payload );
    }
}
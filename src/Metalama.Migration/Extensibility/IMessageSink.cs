namespace PostSharp.Extensibility
{
    public interface IMessageSink
    {
        void Write( Message message );
    }
}
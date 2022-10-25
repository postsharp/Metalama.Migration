namespace PostSharp.Extensibility
{
    public interface IMessageDispenser
    {
        string GetMessage( string key );
    }
}
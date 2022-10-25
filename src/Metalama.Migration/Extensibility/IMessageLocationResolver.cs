namespace PostSharp.Extensibility
{
    public interface IMessageLocationResolver : IService
    {
        MessageLocation GetMessageLocation( object codeElement );
    }
}
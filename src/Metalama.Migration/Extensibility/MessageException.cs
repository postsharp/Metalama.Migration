using System;

namespace PostSharp.Extensibility
{
    public sealed class MessageException : Exception
    {
        public MessageException( Message message )
        {
            throw new NotImplementedException();
        }

        public Message MessageObject { get; }
    }
}
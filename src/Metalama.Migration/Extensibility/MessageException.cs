using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public sealed class MessageException : Exception
    {
        public MessageException( Message message )
        {
            throw new NotImplementedException();
        }

        public Message MessageObject { get; }
    }
}
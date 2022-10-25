using System;
using System.Diagnostics.CodeAnalysis;

namespace PostSharp.Extensibility
{
    [Serializable]
    [SuppressMessage( "Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors" )]
    public sealed class MessageException : Exception
    {
        [SuppressMessage( "Microsoft.Usage", "CA221:DoNotCallOverridableMethodsInConstructor" )]
        public MessageException( Message message )
        {
            throw new NotImplementedException();
        }

        public Message MessageObject { get; }
    }
}
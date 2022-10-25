using System;
using System.Diagnostics.CodeAnalysis;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Exception embedding a <see cref = "Message" />.
    /// </summary>
    [Serializable]
    [SuppressMessage( "Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors" )]
    public sealed class MessageException : Exception
    {
        /// <summary>
        ///   The <see cref = "Message" />.
        /// </summary>
        /// <summary>
        ///   Initializes a new <see cref = "MessageException" /> from
        ///   an existing <see cref = "Message" />.
        /// </summary>
        /// <param name = "message">A <see cref = "Message" />.</param>
        [SuppressMessage( "Microsoft.Usage", "CA221:DoNotCallOverridableMethodsInConstructor" )]
        public MessageException( Message message )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Gets the <see cref = "Message" /> em
        /// </summary>
        public Message MessageObject { get; }
    }
}
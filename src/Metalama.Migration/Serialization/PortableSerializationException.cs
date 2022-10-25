using System;
using System.Runtime.Serialization;

namespace PostSharp.Serialization
{
    /// <summary>
    /// Exception thrown by the <see cref="PortableFormatter"/>.
    /// </summary>
    [Serializable]
    public class PortableSerializationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        /// <summary>
        /// Initializes a new <see cref="PortableSerializationException"/>.
        /// </summary>
        public PortableSerializationException() { }

        /// <summary>
        /// Initializes a new <see cref="PortableSerializationException"/> and specifies the message.
        /// </summary>
        /// <param name="message">Message.</param>
        public PortableSerializationException( string message ) : base( message ) { }

        /// <summary>
        /// Initializes a new <see cref="PortableSerializationException"/> and specifies the message and inner exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="inner">Inner exception.</param>
        public PortableSerializationException( string message, Exception inner ) : base( message, inner ) { }

        /// <summary>
        /// Deserialization constructor.
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected PortableSerializationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}
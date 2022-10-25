using System;
using System.Runtime.Serialization;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Exception thrown at build time by implementation of <see cref = "IValidableAnnotation.CompileTimeValidate" />
    ///   when an annotation is invalid.
    /// </summary>
    [Serializable]
    public class InvalidAnnotationException : Exception
    {
        /// <summary>
        ///   Initializes a new <see cref = "InvalidAnnotationException" /> with default message.
        /// </summary>
        public InvalidAnnotationException() { }

        /// <summary>
        ///   Initializes a new <see cref = "InvalidAnnotationException" /> and with a specified exception message.
        /// </summary>
        /// <param name = "message">Exception message</param>
        public InvalidAnnotationException( string message ) : base( message ) { }

        /// <summary>
        ///   Initializes a new <see cref = "InvalidAnnotationException" /> with a specified exception message
        ///   and inner <see cref = "Exception" />.
        /// </summary>
        /// <param name = "message">Exception message.</param>
        /// <param name = "inner">Inner exception.</param>
        public InvalidAnnotationException( string message, Exception inner ) : base( message, inner ) { }

        /// <summary>
        ///   Deserialization constructor.
        /// </summary>
        /// <param name = "info">Info.</param>
        /// <param name = "context">Context.</param>
        protected InvalidAnnotationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}
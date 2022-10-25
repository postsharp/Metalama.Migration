using System;
using System.Runtime.Serialization;

namespace PostSharp.Extensibility
{
    public class InvalidAnnotationException : Exception
    {
        public InvalidAnnotationException() { }

        public InvalidAnnotationException( string message ) : base( message ) { }

        public InvalidAnnotationException( string message, Exception inner ) : base( message, inner ) { }

        protected InvalidAnnotationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}
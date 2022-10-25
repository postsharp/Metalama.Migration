using System;
using System.Runtime.Serialization;

namespace PostSharp.Serialization
{
    [Serializable]
    public class PortableSerializationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public PortableSerializationException() { }

        public PortableSerializationException( string message ) : base( message ) { }

        public PortableSerializationException( string message, Exception inner ) : base( message, inner ) { }

        protected PortableSerializationException(
            SerializationInfo info,
            StreamingContext context ) : base( info, context ) { }
    }
}
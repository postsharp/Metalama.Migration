// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Runtime.Serialization;

namespace PostSharp.Serialization
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    [Obsolete( "", true )]
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
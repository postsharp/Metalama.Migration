using System;
using System.IO;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// The source code of method bodies and expression bodies is not represented in the high-level API of Metalama.
    /// If you need to access source code from an aspect, you must implement a service using Metalama SDK. 
    /// </summary>
    /// <seealso href="@services"/>
    [Obsolete( "", true )]
    public class MethodBodyFormatter : MethodBodyVisitor
    {
        public MethodBodyFormatter( TextWriter writer )
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Reflection;
using Metalama.Framework.Diagnostics;
using PostSharp.Reflection;
using PostSharp.Reflection.MethodBody;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, the equivalent is <see cref="IDiagnosticLocation"/>.
    /// </summary>
    public class MessageLocation
    {
        public static readonly MessageLocation Unknown;

        public static MessageLocation Of( SymbolSequencePoint symbolSequencePoint )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Explicit( string file, int lineStart, int columnStart, int lineEnd, int columnEnd )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Explicit( string file, int line, int column )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Explicit( string file )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( object codeElement )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( MemberInfo member )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( ParameterInfo parameter )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( LocationInfo location )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( Assembly assembly )
        {
            throw new NotImplementedException();
        }

        public static MessageLocation Of( IExpression expression )
        {
            throw new NotImplementedException();
        }

        public object CodeElement { get; }

        public string File { get; }

        public int StartLine { get; }

        public int StartColumn { get; }

        public int EndLine { get; }

        public int EndColumn { get; }
    }
}
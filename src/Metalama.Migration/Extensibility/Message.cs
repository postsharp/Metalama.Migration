using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Extensibility
{
    public sealed class Message
    {
        #region Fields

        public const int NotAvailable = 0;

        #endregion

        public Message(
            MessageLocation location,
            SeverityType severity,
            string messageId,
            string messageText,
            string helpLink,
            string source,
            Exception innerException )
        {
            throw new NotImplementedException();
        }

        public Message(
            SeverityType severity,
            string messageId,
            string messageText,
            string helpLink,
            string source,
            string locationFile,
            int locationLine,
            int locationColumn,
            Exception innerException )
        {
            throw new NotImplementedException();
        }

        public Message(
            SeverityType severity,
            string messageId,
            string messageText,
            string helpLink,
            string source,
            string locationFile,
            int locationStartLine,
            int locationStartColumn,
            int locationEndLine,
            int locationEndColumn,
            Exception innerException )
        {
            throw new NotImplementedException();
        }

        #region Properties

        public SeverityType Severity { get; internal set; }

        public string MessageId { get; }

        public MessageLocation Location { get; set; }

        public Exception InnerException { get; }

        public string Source { get; }

        public string MessageText { get; }

        public string HelpLink { get; }

        #endregion

        public static string GetExceptionStackMessage( Exception outerException )
        {
            throw new NotImplementedException();
        }

        public static void Write( Message message )
        {
            throw new NotImplementedException();
        }

        public static void Write( MessageLocation messageLocation, SeverityType severity, string errorCode, string message )
        {
            throw new NotImplementedException();
        }

        public static void Write( MessageLocation messageLocation, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public static void Write( MemberInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public static void Write( Type type, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public static void Write( ParameterInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public static void Write( Assembly codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public static void Write( LocationInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            throw new NotImplementedException();
        }
    }
}
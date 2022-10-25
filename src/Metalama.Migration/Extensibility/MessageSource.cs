using System;
using System.Reflection;
using System.Resources;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public class MessageSource :
        MarshalByRefObject,
        IMessageSink
    {
        public MessageSource( string source, ResourceManager resourceManager )

        {
            throw new NotImplementedException();
        }

        public MessageSource( string source, IMessageDispenser messageDispenser )
        {
            throw new NotImplementedException();
        }

        public Message CreateMessage(
            MessageLocation location,
            SeverityType severity,
            string messageId,
            Exception innerException,
            params object[] arguments )
        {
            throw new NotImplementedException();
        }

        public void Write( MessageLocation location, SeverityType severity, string messageId, Exception innerException, params object[] arguments )
        {
            Write( CreateMessage( location, severity, messageId, innerException, arguments ) );
        }

        public void Write( MessageLocation location, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( location, severity, messageId, null, arguments );
        }

        public void Write( MemberInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        public void Write( ParameterInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        public void Write( Assembly codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        #region IMessageSink Members

        public void Write( Message message )
        {
            if (MessageSink == null)
            {
                return;
            }

            MessageSink.Write( message );

            // If we have a fatal error, throw an exception.
            if (message.Severity == SeverityType.Fatal)
            {
                throw new MessageException( message );
            }
        }

        #endregion

        public static IMessageSink MessageSink { get; internal set; }
    }
}
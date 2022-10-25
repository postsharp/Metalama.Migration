using System;
using System.Reflection;
using System.Resources;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides commodity methods to work with an <see cref = "IMessageSink" />.
    /// </summary>
    public class MessageSource :
        MarshalByRefObject,
        IMessageSink
    {
        /// <summary>
        /// Instantiates a <see cref="MessageSource"/> backed by a <see cref="ResourceManager"/>.
        /// </summary>
        /// <param name="source">Source name.</param>
        /// <param name="resourceManager">The <see cref="ResourceManager"/>.</param>
        public MessageSource( string source, ResourceManager resourceManager )

        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Initializes a new <see cref = "MessageSource" /> backed by a <see cref = "IMessageDispenser" />.
        /// </summary>
        /// <param name = "source">Name of the component emitting. the messages.</param>
        /// <param name = "messageDispenser">The <see cref = "IMessageDispenser" /> that will be used to
        ///   retrieve message texts.</param>
        public MessageSource( string source, IMessageDispenser messageDispenser )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a <see cref="Message"/> from the current <see cref="MessageSource"/>.
        /// </summary>
        /// <param name="location">Location of the source code artifact causing the message.</param>
        /// <param name="severity">Severity.</param>
        /// <param name="messageId">Message identifier (resolved by the current <see cref="MessageSource"/>).</param>
        /// <param name="innerException">Exception causing the message, or <c>null</c>.</param>
        /// <param name="arguments">Arguments of the message text.</param>
        /// <returns>A <see cref="Message"/>.</returns>
        public Message CreateMessage(
            MessageLocation location,
            SeverityType severity,
            string messageId,
            Exception innerException,
            params object[] arguments )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Emits a <see cref = "Message" /> and specifies an inner <see cref="Exception"/>.
        /// </summary>
        /// <param name="location">Location of the source code artifact that caused the message.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "arguments">Array of arguments used to format the message text,
        ///   or <c>null</c> if this message has no argument.</param>
        /// <param name = "innerException">The <see cref = "Exception" /> that caused this message,
        ///   or <c>null</c> if this message was not caused by an
        ///   exception.</param>
        public void Write( MessageLocation location, SeverityType severity, string messageId, Exception innerException, params object[] arguments )
        {
            Write( CreateMessage( location, severity, messageId, innerException, arguments ) );
        }

        /// <summary>
        ///   Emits a <see cref = "Message" />.
        /// </summary>
        /// <param name="location">Location of the source code artifact that caused the message.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "arguments">Array of arguments used to format the message text,
        ///   or <c>null</c> if this message has no argument.</param>
        public void Write( MessageLocation location, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( location, severity, messageId, null, arguments );
        }

        /// <summary>
        ///   Emits a <see cref = "Message" />.
        /// </summary>
        /// <param name="codeElement">Source code artifact (<see cref="Type"/>, <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>,
        /// <see cref="FieldInfo"/>, <see cref="EventInfo"/>, <see cref="PropertyInfo"/>) that caused the message.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "arguments">Array of arguments used to format the message text,
        ///   or <c>null</c> if this message has no argument.</param>
        public void Write( MemberInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        /// <summary>
        ///   Emits a <see cref = "Message" />.
        /// </summary>
        /// <param name="codeElement">Source code artifact that caused the message.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "arguments">Array of arguments used to format the message text,
        ///   or <c>null</c> if this message has no argument.</param>
        public void Write( ParameterInfo codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        /// <summary>
        ///   Emits a <see cref = "Message" />.
        /// </summary>
        /// <param name="codeElement">Source code artifact that caused the message.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "arguments">Array of arguments used to format the message text,
        ///   or <c>null</c> if this message has no argument.</param>
        public void Write( Assembly codeElement, SeverityType severity, string messageId, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        #region IMessageSink Members

        /// <inheritdoc />
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

        /// <summary>
        ///   Gets the current message sink.
        /// </summary>
        public static IMessageSink MessageSink { get; internal set; }
    }
}
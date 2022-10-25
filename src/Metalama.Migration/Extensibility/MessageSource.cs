// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using PostSharp.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Provides commodity methods to work with an <see cref = "IMessageSink" />.
    /// </summary>
    public class MessageSource :
#if MARSHAL_BY_REF
        MarshalByRefObject,
#endif
        IMessageSink
    {
        private readonly IMessageDispenser messageDispenser;
        private readonly string source;

        /// <summary>
        /// Instantiates a <see cref="MessageSource"/> backed by a <see cref="ResourceManager"/>.
        /// </summary>
        /// <param name="source">Source name.</param>
        /// <param name="resourceManager">The <see cref="ResourceManager"/>.</param>
        public MessageSource( string source, ResourceManager resourceManager )

        {
            #region Preconditions

            if ( resourceManager == null )
            {
                throw new ArgumentNullException( nameof(resourceManager));
            }
            if ( string.IsNullOrEmpty( source ) )
            {
                throw new ArgumentNullException( nameof(source));
            }

            #endregion

            this.messageDispenser = new ResourceManagerMessageDispenser( resourceManager );
            this.source = source;
        }

        /// <summary>
        ///   Initializes a new <see cref = "MessageSource" /> backed by a <see cref = "IMessageDispenser" />.
        /// </summary>
        /// <param name = "source">Name of the component emitting. the messages.</param>
        /// <param name = "messageDispenser">The <see cref = "IMessageDispenser" /> that will be used to
        ///   retrieve message texts.</param>
        public MessageSource( string source, IMessageDispenser messageDispenser )
        {
            #region Preconditions

            if ( messageDispenser == null )
            {
                throw new ArgumentNullException( nameof(messageDispenser));
            }
            if ( string.IsNullOrEmpty( source ) )
            {
                throw new ArgumentNullException( nameof(source));
            }

            #endregion

            this.messageDispenser = messageDispenser;
            this.source = source;
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
        public Message CreateMessage( MessageLocation location, SeverityType severity, string messageId, Exception innerException,
                                      params object[] arguments )
        {
            string messageText;
            string helpLink;
            this.FormatMessage( messageId, arguments, out messageText, out helpLink );

            return new Message( location, severity, messageId, messageText, helpLink, this.source, innerException );
        }

        private void FormatMessage( string messageId, object[] arguments, out string messageText, out string helpLink )
        {
            string messageTextFormattingString = this.messageDispenser.GetMessage( messageId );

            if ( messageTextFormattingString == null )
            {
                messageText = string.Format( CultureInfo.InvariantCulture, "[{0}]. No message text found!.", messageId );
            }
            else if ( arguments == null )
            {
                messageText = messageTextFormattingString;
            }
            else
            {
                try
                {
                    if ( Formatter != null )
                    {
                        messageText = Formatter.Format(CultureInfo.InvariantCulture,  messageTextFormattingString, arguments );
                    }
                    else
                    {
                        messageText = string.Format(CultureInfo.InvariantCulture, messageTextFormattingString, arguments);
                    }
                }
                catch ( FormatException e )
                {
                    throw new FormatException( "Cannot format the MessageText with id " +
                                               messageId + ".", e );
                }
            }

            string helpLinkFormattingString = this.messageDispenser.GetMessage( messageId + "?" );

            if ( helpLinkFormattingString != null )
            {
                if ( arguments == null )
                {
                    helpLink = helpLinkFormattingString;
                }
                else
                {
                    try
                    {
                        helpLink = string.Format( CultureInfo.InvariantCulture, helpLinkFormattingString, arguments );
                    }
                    catch ( FormatException e )
                    {
                        throw new FormatException( "Cannot format the HelpLink with id " + messageId + ".", e );
                    }
                }
            }
            else
            {
                helpLink = null;
            }
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
            this.Write( this.CreateMessage( location, severity, messageId, innerException, arguments ) );
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
            this.Write( location, severity, messageId, null, arguments );
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
            this.Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
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
            this.Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
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
            this.Write( MessageLocation.Of( codeElement ), severity, messageId, null, arguments );
        }

        #region IMessageSink Members

        /// <inheritdoc />
        public void Write( Message message )
        {
            if ( MessageSink == null )
                return;

            MessageSink.Write( message );

            // If we have a fatal error, throw an exception.
            if ( message.Severity == SeverityType.Fatal )
            {
                throw new MessageException( message );
            }
        }

        #endregion

        /// <summary>
        ///   Gets the current message sink.
        /// </summary>
        public static IMessageSink MessageSink { get; internal set; }

        internal static IMessageFormatter Formatter { get; set; }
    }
}


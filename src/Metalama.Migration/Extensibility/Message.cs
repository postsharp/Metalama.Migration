// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Globalization;
using System.Reflection;
using System.Text;
using PostSharp.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Encapsulates a message (error, warning, info, ...).
    /// </summary>
#if SERIALIZABLE
    [Serializable]
#endif
    public sealed class Message
    {
        #region Fields

        /// <summary>
        /// When set to the <c>locationLine</c> or <c>locationColumn</c> constructor parameter or the <see cref="MessageLocation.StartColumn"/>,
        /// <see cref="MessageLocation.EndColumn"/>, <see cref="MessageLocation.StartLine"/>, <see cref="MessageLocation.EndLine"/>, means that the value of this property is unknown.
        /// </summary>
        public const int NotAvailable = 0;

        private const string customSource = null;

        private static readonly MessageLocation NullLocation = MessageLocation.Explicit( null, NotAvailable, NotAvailable, NotAvailable, NotAvailable );

        #endregion

        /// <summary>
        ///   Initializes a new <see cref = "Message" /> and specifies all its properties.
        /// </summary>
        /// <param name="location">Element of code (<see cref="Assembly"/>, <see cref="Type"/>, <see cref="MethodInfo"/>,
        /// <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>, <see cref="EventInfo"/> or <see cref="ParameterInfo"/>)
        /// to which the message applies. When called from PostSharp.Sdk, the parameter can also contain a <c>MetadataDeclaration</c>.</param>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "messageText">Fully formatted message text.</param>
        /// <param name = "helpLink">Link to the help file page associated to this message.</param>
        /// <param name = "source">Name of the component emitting the message.</param>
        /// <param name = "innerException">The <see cref = "Exception" /> that caused this message,
        ///   or <c>null</c> if this message was not caused by an
        ///   exception.</param>
        public Message( MessageLocation location, SeverityType severity, string messageId, string messageText, string helpLink, string source,
                        Exception innerException )
        {
            #region Preconditions

            if ( string.IsNullOrEmpty( messageId ) )
            {
                throw new ArgumentNullException( nameof(messageId));
            }

            if ( string.IsNullOrEmpty( messageText ) )
            {
                throw new ArgumentNullException( nameof(messageText));
            }

            #endregion

            this.Source = source;
            this.Severity = severity;
            this.MessageId = messageId;
            this.InnerException = innerException;
            this.HelpLink = helpLink;
            this.MessageText = messageText.TrimEnd( '.' ) + ".";


            this.location = location ?? NullLocation;

            if ( this.Severity <= SeverityType.Warning && MessageSource.Formatter != null && MessageSource.Formatter.IsMessageIgnored( messageId, location ) )
            {
                this.Severity = SeverityType.None;
            }
        }


        /// <summary>
        ///   Initializes a new <see cref = "Message" /> and specifies all its properties.
        /// </summary>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "locationFile">File that caused the error, or <c>null</c> if
        ///   the file is unknown or does not apply.</param>
        /// <param name = "locationLine"> Position (line) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "locationColumn">Position (column) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "innerException">The <see cref = "Exception" /> that caused this message,
        ///   or <c>null</c> if this message was not caused by an
        ///   exception.</param>
        /// <param name = "source">Name of the component emitting the message.</param>
        /// <param name = "helpLink">Link to the help file page associated to this message.</param>
        /// <param name = "messageText">Fully formatted message text.</param>
        public Message( SeverityType severity, string messageId,
                        string messageText, string helpLink, string source,
                        string locationFile, int locationLine, int locationColumn, Exception innerException )
        {
            #region Preconditions

            if ( string.IsNullOrEmpty( messageId ) )
            {
                throw new ArgumentNullException( nameof(messageId));
            }

            if ( string.IsNullOrEmpty( messageText ) )
            {
                throw new ArgumentNullException( nameof(messageText));
            }

            #endregion

            this.Source = source;
            this.Severity = severity;
            this.MessageId = messageId;
            this.location = MessageLocation.Explicit( locationFile, locationLine, locationColumn );
            this.InnerException = innerException;
            this.HelpLink = helpLink;
            this.MessageText = messageText;
        }


        /// <summary>
        ///   Initializes a new <see cref = "Message" /> and specifies all its properties.
        /// </summary>
        /// <param name = "severity">Message severity (fatal error, error, info, debug).</param>
        /// <param name = "messageId">Identifier of the message type.</param>
        /// <param name = "locationFile">File that caused the error, or <c>null</c> if
        ///   the file is unknown or does not apply.</param>
        /// <param name = "locationStartLine">Start position (line) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "locationStartColumn">Start position (column) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "locationEndLine">End position (line) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "locationEndColumn">End position (column) in the file that caused the error,
        ///   or <see cref = "NotAvailable" /> if the line is 
        ///   unknown or does not apply.</param>
        /// <param name = "innerException">The <see cref = "Exception" /> that caused this message,
        ///   or <c>null</c> if this message was not caused by an
        ///   exception.</param>
        /// <param name = "source">Name of the component emitting the message.</param>
        /// <param name = "helpLink">Link to the help file page associated to this message.</param>
        /// <param name = "messageText">Fully formatted message text.</param>
        public Message( SeverityType severity, string messageId,
                        string messageText, string helpLink, string source,
                        string locationFile, int locationStartLine, int locationStartColumn,
                        int locationEndLine, int locationEndColumn, Exception innerException )
        {
            #region Preconditions

            if ( string.IsNullOrEmpty( messageId ) )
            {
                throw new ArgumentNullException( nameof(messageId));
            }

            if ( string.IsNullOrEmpty( messageText ) )
            {
                throw new ArgumentNullException( nameof(messageText));
            }


            #endregion

            this.Source = source;
            this.Severity = severity;
            this.OriginalSeverity = severity;
            this.MessageId = messageId;
            this.location = MessageLocation.Explicit( locationFile, locationStartLine, locationStartColumn, locationEndLine, locationEndColumn );
            this.InnerException = innerException;
            this.HelpLink = helpLink;
            this.MessageText = messageText;
        }

        #region Properties

        /// <summary>
        ///   Gets the message severity.
        /// </summary>
        public SeverityType Severity { get; internal set; }

        /// <summary>
        ///   Gets the original message severity.
        /// </summary>
        internal SeverityType OriginalSeverity { get; private set; }

        /// <summary>
        ///   Gets the message type identifier.
        /// </summary>
        public string MessageId { get; private set; }

        private MessageLocation location;

        /// <summary>
        /// Location of the source code artifact causing the message.
        /// </summary>
        public MessageLocation Location
        {
            get { return this.location; }
            set { this.location = value ?? NullLocation; }
        }

        /// <summary>
        ///   Gets the
        /// </summary>
        public Exception InnerException { get; private set; }

        /// <summary>
        ///   Gets or sets the name of the source component.
        /// </summary>
        public string Source { get; private set; }

        /// <summary>
        ///   Gets the message formatted text.
        /// </summary>
        public string MessageText { get; private set; }

        /// <summary>
        ///   Gets the help link.
        /// </summary>
        public string HelpLink { get; private set; }

        #endregion

        /// <summary>
        ///   Returns a string composed of the messages of
        ///   all inner exceptions.
        /// </summary>
        /// <param name = "outerException">The outer exception.</param>
        /// <returns>A string composed of the messages of all
        ///   <paramref name = "outerException" /> and all inner exceptions,
        ///   concatenated by the string <c>--&gt;</c>.</returns>
        public static string GetExceptionStackMessage( Exception outerException )
        {
            #region Preconditions

            if ( outerException == null )
            {
                throw new ArgumentNullException( nameof(outerException));
            }

            #endregion

            Exception cursor = outerException;
            StringBuilder builder = new StringBuilder();
            while ( cursor != null )
            {
                if ( builder.Length > 0 )
                {
                    builder.Append( " --> " );
                }
                builder.Append( cursor.Message );
                cursor = cursor.InnerException;
            }

            return builder.ToString();
        }

        /// <summary>
        ///   Writes a message by providing a <see cref = "Message" /> object.
        /// </summary>
        /// <param name = "message">A <see cref = "Message" />.</param>
        public static void Write( Message message )
        {
            if ( MessageSource.MessageSink == null )
                return;
            MessageSource.MessageSink.Write( message );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "message">Error message.</param>
        /// <param name="messageLocation">Element of code (<see cref="Assembly"/>, <see cref="Type"/>, <see cref="MethodInfo"/>,
        /// <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>, <see cref="EventInfo"/> or <see cref="ParameterInfo"/>)
        /// to which the message applies. When called from PostSharp.Sdk, the parameter can also contain a <c>MetadataDeclaration</c>.</param>
        public static void Write( MessageLocation messageLocation, SeverityType severity, string errorCode, string message )
        {
            if ( MessageSource.MessageSink == null )
                return;
            MessageSource.MessageSink.Write( new Message( messageLocation, severity, errorCode, message, null, customSource, null ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="messageLocation">Element of code (<see cref="Assembly"/>, <see cref="Type"/>, <see cref="MethodInfo"/>,
        /// <see cref="ConstructorInfo"/>, <see cref="PropertyInfo"/>, <see cref="EventInfo"/> or <see cref="ParameterInfo"/>)
        /// to which the message applies. When called from PostSharp.Sdk, the parameter can also contain a <c>MetadataDeclaration</c>.</param>
        public static void Write( MessageLocation messageLocation, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( messageLocation, severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="codeElement">Element of code to which the message applies.</param>
        public static void Write( MemberInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="type">Element of code to which the message applies.</param>
        public static void Write( Type type, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( MessageLocation.Of( type ), severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="codeElement">Element of code to which the message applies.</param>
        public static void Write( ParameterInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="codeElement">Element of code to which the message applies.</param>
        public static void Write( Assembly codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }

        /// <summary>
        ///   Writes a message.
        /// </summary>
        /// <param name = "severity">Severity.</param>
        /// <param name = "errorCode">Error code.</param>
        /// <param name = "format">Error message formatting string.</param>
        /// <param name = "arguments">Formatting string arguments.</param>
        /// <param name="codeElement">Element of code to which the message applies.</param>
        public static void Write( LocationInfo codeElement, SeverityType severity, string errorCode, string format, params object[] arguments )
        {
            Write( MessageLocation.Of( codeElement ), severity, errorCode, MessageSource.Formatter.Format(CultureInfo.InvariantCulture, format, arguments ) );
        }
    }
}


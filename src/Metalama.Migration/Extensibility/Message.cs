using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Encapsulates a message (error, warning, info, ...).
    /// </summary>
    [Serializable]
    public sealed class Message
    {
        #region Fields

        /// <summary>
        /// When set to the <c>locationLine</c> or <c>locationColumn</c> constructor parameter or the <see cref="MessageLocation.StartColumn"/>,
        /// <see cref="MessageLocation.EndColumn"/>, <see cref="MessageLocation.StartLine"/>, <see cref="MessageLocation.EndLine"/>, means that the value of this property is unknown.
        /// </summary>
        public const int NotAvailable = 0;

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

        /// <summary>
        ///   Gets the message severity.
        /// </summary>
        public SeverityType Severity { get; internal set; }

        /// <summary>
        ///   Gets the message type identifier.
        /// </summary>
        public string MessageId { get; }

        /// <summary>
        /// Location of the source code artifact causing the message.
        /// </summary>
        public MessageLocation Location { get; set; }

        /// <summary>
        ///   Gets the
        /// </summary>
        public Exception InnerException { get; }

        /// <summary>
        ///   Gets or sets the name of the source component.
        /// </summary>
        public string Source { get; }

        /// <summary>
        ///   Gets the message formatted text.
        /// </summary>
        public string MessageText { get; }

        /// <summary>
        ///   Gets the help link.
        /// </summary>
        public string HelpLink { get; }

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
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Writes a message by providing a <see cref = "Message" /> object.
        /// </summary>
        /// <param name = "message">A <see cref = "Message" />.</param>
        public static void Write( Message message )
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
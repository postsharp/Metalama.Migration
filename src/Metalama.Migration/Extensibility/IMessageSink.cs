namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Receives messages.
    /// </summary>
    /// <remarks>
    ///   Use this interface instead of events for cross-domain communication.
    /// </remarks>
    public interface IMessageSink
    {
        /// <summary>
        ///   Writes a message to the sink.
        /// </summary>
        /// <param name = "message">A message.</param>
        void Write( Message message );
    }
}
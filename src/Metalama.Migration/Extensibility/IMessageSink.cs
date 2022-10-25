// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


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


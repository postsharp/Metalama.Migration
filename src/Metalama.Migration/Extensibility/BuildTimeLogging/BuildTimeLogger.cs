using System;
using System.Collections.Generic;

namespace PostSharp.Extensibility.BuildTimeLogging
{
    /// <summary>
    ///  Allows to emit build-time log records. Use the <see cref="GetInstance(string)"/> method
    ///  and then invoke <see cref="WriteLine(string)"/> or <see cref="Activity(string)"/> using the <c>?.</c>
    ///  operator.
    /// </summary>
    public sealed partial class BuildTimeLogger
    {
        /// <summary>
        ///   Writes a preformatted log message.
        /// </summary>
        /// <param name = "message">Message.</param>
        public void WriteLine( string message )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a log message and specifies the formatting string and an array of parameters.
        /// </summary>
        /// <param name="message">Message formatting string.</param>
        /// <param name="args">Formatting string arguments.</param>
        public void WriteLine( string message, object[] args )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Appends a preformatted string to the next message. The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "message">Message.</param>
        public void Write( string message )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and an array of parameters. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "message">Message formatting string.</param>
        /// <param name="args">Formatting string arguments.</param>
        public void Write( string message, object[] args )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a preformatted message and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
        public BuildTimeLogActivity Activity( string message )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a <see cref="BuildTimeLogger"/> for a given category, or <c>null</c> if
        /// logging is not enabled for this category. 
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>A <see cref="BuildTimeLogger"/> for the <paramref name="category"/> if logging
        /// is enabled for the <paramref name="category"/>, otherwise <c>null</c>.</returns>
        public static BuildTimeLogger GetInstance( string category )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes the <see cref="BuildTimeLogger"/> facility.
        /// </summary>
        /// <param name="enabledCategories">The set of enabled categories. This set cannot be changed after initialization.</param>
        public static void Initialize( IEnumerable<string> enabledCategories = null ) => throw new NotImplementedException();

        /// <summary>
        /// Determines whether the <see cref="Initialize"/> method has already been invoked.
        /// </summary>
        public static bool IsInitialized => throw new NotImplementedException();
    }
}
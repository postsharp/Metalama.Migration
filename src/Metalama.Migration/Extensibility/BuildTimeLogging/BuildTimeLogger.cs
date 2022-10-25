// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PostSharp.Extensibility.BuildTimeLogging
{
    /// <summary>
    ///  Allows to emit build-time log records. Use the <see cref="GetInstance(string)"/> method
    ///  and then invoke <see cref="WriteLine(string)"/> or <see cref="Activity(string)"/> using the <c>?.</c>
    ///  operator.
    /// </summary>
    public sealed partial class BuildTimeLogger
    {
        private const string indentSpaces = "   ";
        private readonly string category;
        private readonly StringBuilder lineBuffer = new StringBuilder();
        private static int indent;
        private static readonly char[] eol = Environment.NewLine.ToCharArray();


        private BuildTimeLogger(string category)
        {
            #region Preconditions

            if (category == null) throw new ArgumentNullException(nameof(category));

            #endregion

            this.category = category;

        }


        private void InternalWrite(string message)
        {
            this.lineBuffer.Append(message);
        }

        private void InternalWriteLine(string message)
        {
        
            string msg;
            if (this.lineBuffer.Length > 0)
            {
                this.lineBuffer.Append(message);
                msg = this.lineBuffer.ToString();
            }
            else
            {
                msg = message;
            }

            if ( indent > 0 )
            {
                string indentString = new string(' ', indent * indentSpaces.Length );
                msg  = string.Join( Environment.NewLine, msg.Split(eol[eol.Length-1]).Select( s => indentString + s.TrimEnd( eol) ).ToArray() );
            }

            Message.Write(
                new Message(MessageLocation.Unknown, SeverityType.Info, this.category, msg, null, "Trace", null));

#if DEBUGGER_LOG
            if (Debugger.IsAttached)
            {
                Debugger.Log(0, this.category, msg + "\n");
            }
#endif
        }



        /// <summary>
        ///   Writes a preformatted log message.
        /// </summary>
        /// <param name = "message">Message.</param>
        public void WriteLine(string message)
        {
            this.InternalWriteLine(message);

        }

        /// <summary>
        /// Writes a log message and specifies the formatting string and an array of parameters.
        /// </summary>
        /// <param name="message">Message formatting string.</param>
        /// <param name="args">Formatting string arguments.</param>
        public void WriteLine(string message, object[] args )
        {
            this.InternalWriteLine(SafeStringFormat(message, args));
        }

        private static string SafeStringFormat( string format, params object[] args )
        {
            if ( args != null && args.Length == 1 )
            {
                if ( args[0] is object[] nestedArgs )
                {
                    args = nestedArgs;
                }
            }

            try
            {
                return string.Format(CultureInfo.InvariantCulture, format, args );
            }
            catch ( Exception )
            {
                return "Error in formatting string: " + format;
            }
        }

        /// <summary>
        ///   Appends a preformatted string to the next message. The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "message">Message.</param>
        public void Write(string message)
        {
            this.InternalWrite(message);
        }

        /// <summary>
        ///   Appends a string to the next message and formats it using a formatting string and an array of parameters. 
        ///   The message is sent and flushed when the <see cref="WriteLine(string)"/> method is invoked.
        /// </summary>
        /// <param name = "message">Message formatting string.</param>
        /// <param name="args">Formatting string arguments.</param>
        public void Write(string message, object[] args)
        {
            this.InternalWrite(SafeStringFormat(message, args));
        }


        /// <summary>
        /// Writes a preformatted message and increases the indentation level. To decrease the indentation level, dispose the <see cref="BuildTimeLogActivity"/>
        /// returned by this method.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>An opaque object to be disposed at the end of the activity to decrease the indentation level.</returns>
        public BuildTimeLogActivity Activity(string message)
        {
            this.InternalWriteLine(message);
            indent++;
            return new BuildTimeLogActivity(true);
        }



        
        /// <summary>
        /// Gets a <see cref="BuildTimeLogger"/> for a given category, or <c>null</c> if
        /// logging is not enabled for this category. 
        /// </summary>
        /// <param name="category">The name of the category.</param>
        /// <returns>A <see cref="BuildTimeLogger"/> for the <paramref name="category"/> if logging
        /// is enabled for the <paramref name="category"/>, otherwise <c>null</c>.</returns>
        public static BuildTimeLogger GetInstance(string category)
        {
            if ( string.IsNullOrEmpty(category ) )
                throw new ArgumentNullException(nameof(category ) );

            if (BuildTimeLoggingConfiguration.IsEnabled(category))
                return new BuildTimeLogger(category);
            else
                return null;
        }

        internal static void WhenLoggerEnabled( string category, Action<BuildTimeLogger> action )
        {
            BuildTimeLoggingConfiguration.WhenEnabled(category,
                                                      c => {
                                                                action(new BuildTimeLogger(c) );
                                                            } );
        }

        internal static void UnindentCore()
        {
            indent--;
        }

        // Intentionally non-static.
        [Obsolete("Use Activity.")]
        internal void Indent()
        {
            indent++ ;
        }

        // Intentionally non-static.
        [Obsolete("Use Activity.")]
        internal void Unindent()
        {
            indent--;
        }

        /// <summary>
        /// Initializes the <see cref="BuildTimeLogger"/> facility.
        /// </summary>
        /// <param name="enabledCategories">The set of enabled categories. This set cannot be changed after initialization.</param>
        public static void Initialize( IEnumerable<string> enabledCategories = null ) => BuildTimeLoggingConfiguration.Initialize(enabledCategories);

        /// <summary>
        /// Determines whether the <see cref="Initialize"/> method has already been invoked.
        /// </summary>
        public static bool IsInitialized => BuildTimeLoggingConfiguration.IsInitialized;


    }
}


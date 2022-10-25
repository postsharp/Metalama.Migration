using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Provides a base implementation of <see cref="IMessageDispenser"/>
    /// where the message key is supposed to be in format <c>PRE0000</c>, where
    /// <c>PRE</c> is a prefix and <c>0000</c> is an integer. Keys for help URLs
    /// have the format <c>PRE0000?</c>.
    /// </summary>
    public abstract class MessageDispenser : IMessageDispenser
    {
        /// <summary>
        /// Initializes a new <see cref="MessageDispenser"/>.
        /// </summary>
        /// <param name="prefix">Prefix of all messages provided by the new dispenser.</param>
        protected MessageDispenser( string prefix )
        {
            Prefix = prefix ?? "";
        }

        /// <summary>
        /// Gets the message prefix.
        /// </summary>
        public string Prefix { get; }

        /// <inheritdoc />
        public string GetMessage( string key )
        {
            if (!key.StartsWith( Prefix, StringComparison.Ordinal ))
            {
                return null;
            }

            var isHelp = key.EndsWith( "?", StringComparison.Ordinal );

            if (isHelp)
            {
                key = key.TrimEnd( '?' );
            }

            int number;

            if (!int.TryParse( key.Substring( Prefix.Length ), out number ))
            {
                return null;
            }

            if (isHelp)
            {
                return GetHelpUrl( number );
            }
            else
            {
                return GetMessage( number );
            }
        }

        /// <summary>
        /// Gets the message text of a given number.
        /// </summary>
        /// <param name="number">Message number.</param>
        /// <returns>The message text corresponding to <paramref name="number"/>.</returns>
        protected abstract string GetMessage( int number );

#pragma warning disable CA1055 // Uri return values should not be strings
        /// <summary>
        /// Gets the message help URL of a given number.
        /// </summary>
        /// <param name="number">Message number.</param>
        /// <returns>The message help URL corresponding to <paramref name="number"/>.</returns>
        protected virtual string GetHelpUrl( int number )
#pragma warning restore CA1055 // Uri return values should not be strings
        {
            return null;
        }
    }
}
using System;

namespace PostSharp.Extensibility
{
    public abstract class MessageDispenser : IMessageDispenser
    {
        protected MessageDispenser( string prefix )
        {
            Prefix = prefix ?? "";
        }

        public string Prefix { get; }

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

        protected abstract string GetMessage( int number );

#pragma warning disable CA1055 // Uri return values should not be strings

        protected virtual string GetHelpUrl( int number )
#pragma warning restore CA1055 // Uri return values should not be strings
        {
            return null;
        }
    }
}
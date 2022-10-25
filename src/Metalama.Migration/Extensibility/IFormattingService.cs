using System;

namespace PostSharp.Extensibility
{
    public interface IFormattingService : IService
    {
        [Obsolete( "Pass the IFormatProvider. This helps the analyzers." )]
        string Format( string format, params object[] arguments );

        string Format( IFormatProvider provider, string format, params object[] arguments );
    }
}
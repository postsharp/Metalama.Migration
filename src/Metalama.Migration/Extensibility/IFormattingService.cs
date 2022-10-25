using System;
using Metalama.Framework.Project;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// In Metalama, use <see cref="MetalamaExecutionContext"/>.<see cref="MetalamaExecutionContext.Current"/>.<see cref="IExecutionContext.FormatProvider"/>.
    /// </summary>
    public interface IFormattingService : IService
    {
        [Obsolete( "Pass the IFormatProvider. This helps the analyzers." )]
        string Format( string format, params object[] arguments );

        string Format( IFormatProvider provider, string format, params object[] arguments );
    }
}
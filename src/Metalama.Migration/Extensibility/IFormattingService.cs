// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Provides a service similar to <see cref="string.Format(string,object[])"/>, but uses
    /// the same formatter as the one used by PostSharp for error messages. This formatter
    /// does a better job at formatting objects like <see cref="Type"/> or <see cref="MethodInfo"/>.
    /// </summary>
    public interface IFormattingService : IService
    {
        /// <summary>
        /// Formats a string with the default <see cref="IFormatProvider"/>.
        /// </summary>
        /// <param name="format">The formatting string.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>The formatted string where parameters in <paramref name="format"/> are replaced by formatted <paramref name="arguments"/>.</returns>
        [Obsolete("Pass the IFormatProvider. This helps the analyzers.")]
        string Format( string format, params object[] arguments );

        /// <summary>
        /// Formats a string and specifies the <see cref="IFormatProvider"/>.
        /// </summary>
        /// <param name="provider">An <see cref="IFormatProvider"/>.</param>
        /// <param name="format">The formatting string.</param>
        /// <param name="arguments">Arguments.</param>
        /// <returns>The formatted string where parameters in <paramref name="format"/> are replaced by formatted <paramref name="arguments"/>.</returns>
        string Format( IFormatProvider provider, string format, params object[] arguments );
    }
}

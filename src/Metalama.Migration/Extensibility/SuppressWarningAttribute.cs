// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;
using System.Diagnostics;
using PostSharp.Constraints;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Instructs PostSharp to ignore warnings and information messages. Errors cannot be ignored.
    /// </summary>
    /// <remarks>
   /// </remarks>
    [AttributeUsage( AttributeTargets.All, AllowMultiple = true, Inherited = false )]
    public class SuppressWarningAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="SuppressWarningAttribute"/>.
        /// </summary>
        /// <param name="messageId">Identifier of the ignored warning.</param>
        public SuppressWarningAttribute( string messageId )
        {
            this.MessageId = messageId;
        }

        /// <summary>
        /// Gets the identifier of the ignored warning.
        /// </summary>
        public string MessageId { get; private set; }

        /// <summary>
        /// Gets or set the reason (a human-readable text) why the warning must be ignored.
        /// </summary>
        public string Reason { get; set; }

    }
}
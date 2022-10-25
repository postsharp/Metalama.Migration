// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Custom attribute that, when applied on an assembly, means that a given message
    ///   should be escalated to an error during the current <c>PostSharp</c> session.
    /// </summary>
    /// <remarks>
    ///   Errors and fatal errors cannot be disabled.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true )]
    public sealed class EscalatePostSharpMessageAttribute : Attribute
    {
        private readonly string messageId;

        /// <summary>
        ///   Initializes a new <see cref = "EscalatePostSharpMessageAttribute" />.
        /// </summary>
        /// <param name = "messageId">Identifier of the message to be disabled.</param>
        public EscalatePostSharpMessageAttribute( string messageId )
        {
            this.messageId = messageId;
        }

        /// <summary>
        ///   Gets the identifier of the message to be disabled.
        /// </summary>
        public string MessageId
        {
            get { return this.messageId; }
        }
    }
}
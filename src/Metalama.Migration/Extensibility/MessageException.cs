// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
#if SERIALIZABLE
using System.Runtime.Serialization;
using System.Security.Permissions;
#endif
namespace PostSharp.Extensibility
{
    /// <summary>
    ///   Exception embedding a <see cref = "Message" />.
    /// </summary>
#if SERIALIZABLE
    [Serializable]
#endif
    [SuppressMessage( "Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors" )]
    public sealed class MessageException : Exception
    {
        /// <summary>
        ///   The <see cref = "Message" />.
        /// </summary>
        private readonly Message message;

        /// <summary>
        ///   Initializes a new <see cref = "MessageException" /> from
        ///   an existing <see cref = "Message" />.
        /// </summary>
        /// <param name = "message">A <see cref = "Message" />.</param>
        [SuppressMessage( "Microsoft.Usage", "CA221:DoNotCallOverridableMethodsInConstructor" )]
        public MessageException( Message message ) : base( GetMessageText( message ) )
        {
            #region Preconditions

            if ( message == null )
            {
                throw new ArgumentNullException( nameof(message));
            }

            #endregion

            this.message = message;
            this.Source = message.Source ?? "PostSharp";
            this.HelpLink = message.HelpLink;
        }

#if SERIALIZABLE
        /// <summary>
        ///   Deserializes a <see cref = "MessageException" />.
        /// </summary>
        /// <param name = "info">Serialization information.</param>
        /// <param name = "context">Serialization context.</param>
        private MessageException(
            SerializationInfo info,
            StreamingContext context )
            : base( info, context )
        {
            this.message = (Message) info.GetValue( "mo", typeof(Message) );
        }


        /// <summary>
        ///   Serializes the current object.
        /// </summary>
        /// <param name = "info">Serialization information.</param>
        /// <param name = "context">Serialization context.</param>
        //[SecurityPermission( SecurityAction.Demand, SerializationFormatter = true )]
        [SecurityCritical]
        public override void GetObjectData( SerializationInfo info, StreamingContext context )
        {
            #region Preconditions

            if ( info == null )
            {
                throw new ArgumentNullException( nameof(info));
            }

            #endregion

            base.GetObjectData( info, context );
            info.AddValue( "mo", this.message );
        }
#endif

        /// <summary>
        ///   Gets the <see cref = "Message" /> em
        /// </summary>
        public Message MessageObject
        {
            get { return this.message; }
        }

        /// <summary>
        ///   Gets the message text.
        /// </summary>
        /// <param name = "message">A <see cref = "Message" />.</param>
        /// <returns>The message text.</returns>
        private static string GetMessageText( Message message )
        {
            if ( message == null )
            {
                return null;
            }
            else
            {
                return message.MessageText;
            }
        }
    }
}

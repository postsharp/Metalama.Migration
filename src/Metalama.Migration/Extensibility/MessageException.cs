// Copyright (c) SharpCrafters s.r.o. All rights reserved.
// This project is not open source. Please see the LICENSE.md file in the repository root for details.

using System;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// No equivalent in Metalama.
    /// </summary>
    public sealed class MessageException : Exception
    {
        public MessageException( Message message )
        {
            throw new NotImplementedException();
        }

        public Message MessageObject { get; }
    }
}
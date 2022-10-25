// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.
namespace PostSharp.Extensibility
{
    /// <summary>
    /// The wrapper class used to specify that the given code element must be formatted in the message verbatim.
    /// For example, display a compiler-generated method name explicitly instead of redirecting to the user-generated method.
    /// </summary>
    internal sealed class VerbatimMessageLocation
    {
        /// <summary>
        /// Creates a new instance of <see cref="VerbatimMessageLocation"/>.
        /// </summary>
        /// <param name="codeElement">The code element that must be formatted verbatim in the message.</param>
        public VerbatimMessageLocation( object codeElement )
        {
            this.CodeElement = codeElement;
        }

        /// <summary>
        /// The underlying code element that will be formatted verbatim in the message.
        /// </summary>
        public object CodeElement { get; }
    }
}

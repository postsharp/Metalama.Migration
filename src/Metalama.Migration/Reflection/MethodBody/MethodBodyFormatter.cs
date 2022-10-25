using System;
using System.IO;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Formats an <see cref="IMethodBodyElement"/> to a textual representation, for debugging purposes.
    /// </summary>
    public class MethodBodyFormatter : MethodBodyVisitor
    {
        /// <summary>
        /// Initializes a new <see cref="MethodBodyFormatter"/>.
        /// </summary>
        /// <param name="writer">A  <see cref="TextWriter"/> where the textual representation will be written.</param>
        public MethodBodyFormatter( TextWriter writer )
        {
            throw new NotImplementedException();
        }
    }
}
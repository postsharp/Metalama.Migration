// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.

using System.IO;
using System.Text;

namespace PostSharp.Reflection.MethodBody
{
    internal sealed class IndentedTextWriter : TextWriter
    {
#pragma warning disable CA2213 // Responsibility of the caller to dispose.
        private readonly TextWriter underlying;
#pragma warning restore CA2213 
        private bool newLine;

        public IndentedTextWriter(TextWriter underlying)
        {
            this.underlying = underlying;
            this.newLine = false;
        }

        public int Indent { get; set; }

        public override void WriteLine(string value)
        {
            this.WriteIndentationIfRequired();
            this.underlying.WriteLine(value);
            this.newLine = true;
        }

        public override void Write(char value)
        {
            this.WriteIndentationIfRequired();
            this.underlying.Write(value);

            if ( value == '\n' )
            {
                this.newLine = true;
            }
        }

        public override void Write(string value)
        {
            string[] lines = value.Split( '\n' );

            for ( int i = 0; i < lines.Length; i++ )
            {
                if ( i < lines.Length - 1 )
                {
                    this.WriteIndentationIfRequired();
                    this.underlying.WriteLine( lines[i] );
                    this.newLine = true;
                }
                else
                {
                    this.WriteIndentationIfRequired();
                    this.underlying.Write( lines[i] );
                }
            }
        }

        private void WriteIndentationIfRequired()
        {
            if (this.newLine)
            {
                if (this.Indent > 0)
                {
                    this.underlying.Write(new string(' ', 2 * this.Indent));
                }

                this.newLine = false;
            }
        }

        public override Encoding Encoding
        {
            get { return this.underlying.Encoding; }
        }
    }
}

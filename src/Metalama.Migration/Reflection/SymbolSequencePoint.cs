// Copyright (c) SharpCrafters s.r.o. This file is not open source. It is released under a commercial
// source-available license. Please see the LICENSE.md file in the repository root for details.


using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace PostSharp.Reflection
{
    /// <summary>
    ///   Maps a point in IL instructions to location in source code.
    /// </summary>
    /// <remarks>
    ///   This class implements the <see cref = "IComparable{T}" /> interface.
    ///   This allows sorting sequence points according to their IL offsets and performing
    ///   binary searches in sorted arrays.
    /// </remarks>
    public  class SymbolSequencePoint :
        IComparable<SymbolSequencePoint>, IEquatable<SymbolSequencePoint>
    {
        #region Fields

        /// <summary>
        ///   Start line in the source code.
        /// </summary>
        private readonly int startLine;

        /// <summary>
        ///   Start column in the source code.
        /// </summary>
        private readonly int startColumn;

        /// <summary>
        ///   End line in the source code.
        /// </summary>
        private readonly int endLine;

        /// <summary>
        ///   End column in the source code.
        /// </summary>
        private readonly int endColumn;

        /// <summary>
        ///   Offset in the IL binary code.
        /// </summary>
        private readonly int offset;

        #endregion

        internal const int HiddenValue = 0xfeefee;
        internal const int TrampolineValue = 0xfeefed;
        internal const int BindingValue = 0xfeefec;
        internal const int StepIntoValue = 0xfeefeb;
        internal const int StepOutValue = 0xfeefea;
        internal const int FinallyValue = 0xfeefe9;
        internal const int TrampolineWithFinallyValue = 0xfeefe8;

        /// <summary>
        ///   Gets a symbol meaning that the associated instructions have no source code.
        /// </summary>
        [SuppressMessage( "Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes" )]
        public static readonly SymbolSequencePoint Hidden = new SymbolSequencePoint( -1, HiddenValue, 0, HiddenValue, 0, null, null );
        internal static readonly SymbolSequencePoint Trampoline = new SymbolSequencePoint(-1, TrampolineValue, 0, TrampolineValue, 0, null, null);
        internal static readonly SymbolSequencePoint Binding = new SymbolSequencePoint(-1, BindingValue, 0, BindingValue, 0, null, null);
        internal static readonly SymbolSequencePoint StepInto = new SymbolSequencePoint(-1, StepIntoValue, 0, StepIntoValue, 0, null, null);
        internal static readonly SymbolSequencePoint StepOut = new SymbolSequencePoint(-1, StepOutValue, 0, StepOutValue, 0, null, null);
        internal static readonly SymbolSequencePoint Finally = new SymbolSequencePoint(-1, FinallyValue, 0, FinallyValue, 0, null, null);
        internal static readonly SymbolSequencePoint TrampolineWithFinally = new SymbolSequencePoint(-1, TrampolineWithFinallyValue, 0, TrampolineWithFinallyValue, 0, null, null);

        internal SymbolSequencePoint( int offset ) : this(
            offset, 0, 0, 0, 0, null, null )
        {
        }


        /// <summary>
        ///   Initializes a new <see cref = "SymbolSequencePoint" />.
        /// </summary>
        /// <param name = "offset">The offset of the current sequence point in the IL stream,
        ///   w.r.t. the first byte of the method body.</param>
        /// <param name = "startLine">The start line in the source file.</param>
        /// <param name = "startColumn">The start column in the source file.</param>
        /// <param name = "endLine">The end line in the source file.</param>
        /// <param name = "endColumn">The end column in the source file.</param>
        /// <param name = "document">Source file.</param>
        /// <param name="sourceDeclaration">The source code element declaration containing this symbol sequence point.</param>
        internal SymbolSequencePoint( int offset, int startLine, int startColumn, int endLine, int endColumn,
                                      ISourceDocument document, object sourceDeclaration )
        {
            this.offset = offset;
            this.startLine = startLine;
            this.startColumn = startColumn;
            this.endLine = endLine;
            this.endColumn = endColumn;
            this.SourceDocument = document;
            this.SourceDeclaration = sourceDeclaration;
        }


        /// <summary>
        ///   Initializes a new <see cref = "SymbolSequencePoint" />.
        /// </summary>
        /// <param name = "startLine">The start line in the source file.</param>
        /// <param name = "startColumn">The start column in the source file.</param>
        /// <param name = "endLine">The end line in the source file.</param>
        /// <param name = "endColumn">The end column in the source file.</param>
        /// <param name = "document">Source file.</param>
        /// <param name="sourceDeclaration">The source code element declaration containing this symbol sequence point.</param>
        internal SymbolSequencePoint( int startLine, int startColumn, int endLine, int endColumn, ISourceDocument document, object sourceDeclaration )
            : this ( 0, startLine, startColumn, endLine, endColumn, document, sourceDeclaration )
        {
        }


        internal SymbolSequencePoint( SymbolSequencePoint other )
        {
            this.startLine = other.startLine;
            this.startColumn = other.startColumn;
            this.endLine = other.endLine;
            this.endColumn = other.endColumn;
            this.SourceDocument = other.SourceDocument;
            this.SourceDeclaration = other.SourceDeclaration;
            this.Kind = other.Kind;
        }


        /// <summary>
        ///   Determines whether the current symbol means that the associated
        ///   instructions have no source code.
        /// </summary>
        public bool IsHidden
        {
            get { return this.startLine == HiddenValue; }
        }

        /// <summary>
        /// Determines whether the current symbol is a special, non-standard, defined
        /// by PostSharp and supported by PostSharp Tools for Visual Studio.
        /// </summary>
        public bool IsSpecial
        {
            get { return this.startLine > 0xfee000 && this.startLine != HiddenValue; }
        }

        /// <summary>
        ///   Gets the start line in the source file.
        /// </summary>
        public int StartLine
        {
            get { return this.startLine; }
        }

        /// <summary>
        ///   Gets the end line in the source file.
        /// </summary>
        public int EndLine
        {
            get { return this.endLine; }
        }

        /// <summary>
        ///   Gets the start column in the source file.
        /// </summary>
        public int StartColumn
        {
            get { return this.startColumn; }
        }

        /// <summary>
        ///   Gets the end column in the source file.
        /// </summary>
        public int EndColumn
        {
            get { return this.endColumn; }
        }

        /// <summary>
        ///   Gets the offset in the IL method body.
        /// </summary>
        internal int Offset
        {
            get { return this.offset; }
        }

        /// <summary>
        /// Document (file of source code) containing the current sequence point.
        /// </summary>
        public ISourceDocument SourceDocument { get; }

        /// <summary>
        /// The source code element declaration containing the current sequence point.
        /// </summary>
        internal object SourceDeclaration { get; set; }

        /// <summary>
        /// The kind of the symbol sequence point.
        /// </summary>
        internal SymbolSequencePointKind Kind { get; set; }        

        
        /// <inheritdoc />
        public int CompareTo( SymbolSequencePoint other )
        {
            return this.offset.CompareTo( other.offset );
        }

        
        #region IEquatable<SymbolSequencePoint> Members

        /// <inheritdoc />
        public bool Equals( SymbolSequencePoint other )
        {
            if ( ReferenceEquals( other, null ) )
            {
                return false;
            }

            return
                this.endColumn == other.endColumn &&
                this.endLine == other.endLine &&
                this.offset == other.offset &&
                this.startColumn == other.startColumn &&
                this.startLine == other.startLine;
        }

        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            SymbolSequencePoint symbolSequencePoint = obj as SymbolSequencePoint;

            if ( !ReferenceEquals( symbolSequencePoint, null ) )
            {
                return this.Equals( symbolSequencePoint );
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///   Determines whether two sequence points are equal.
        /// </summary>
        /// <param name = "left">A <see cref = "SymbolSequencePoint" />.</param>
        /// <param name = "right">A <see cref = "SymbolSequencePoint" />.</param>
        /// <returns><c>true</c> if both sequence points are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            if ( ReferenceEquals( right, null ) )
            {
                if ( ReferenceEquals( left, null ) )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return left.Equals( right );
        }

        /// <summary>
        ///   Determines whether two sequence points are different.
        /// </summary>
        /// <param name = "left">A <see cref = "SymbolSequencePoint" />.</param>
        /// <param name = "right">A <see cref = "SymbolSequencePoint" />.</param>
        /// <returns><c>true</c> if both sequence points are different, otherwise <c>false</c>.</returns>
        public static bool operator !=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            if ( ReferenceEquals( right, null ) )
            {
                if ( ReferenceEquals( left, null ) )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }


            return !left.Equals( right );
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.startLine;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            if ( this.offset >= 0 )
                builder.AppendFormat(CultureInfo.InvariantCulture, "{0:x} -> ", this.offset );

            if ( this.IsHidden )
            {
                builder.Append( "hidden" );
            }
            else if ( this.IsSpecial )
            {
                builder.Append( $"special({this.StartLine:x})" );
            }
            else
            {
                builder.AppendFormat(
                    CultureInfo.InvariantCulture,
                    "{4}, {0}-{1}, {2}-{3}",
                    this.startLine, this.endLine,
                    this.startColumn, this.endColumn, this.SourceDocument.FileName );
            }

            return builder.ToString();
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <(SymbolSequencePoint left, SymbolSequencePoint right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=(SymbolSequencePoint left, SymbolSequencePoint right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >(SymbolSequencePoint left, SymbolSequencePoint right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=(SymbolSequencePoint left, SymbolSequencePoint right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        #endregion
    }

    internal enum SymbolSequencePointKind : byte
    {
        Default,
        Entry,
        Exit,
        Disabled
    }
}

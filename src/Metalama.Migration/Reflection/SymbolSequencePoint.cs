using System;
using System.Diagnostics.CodeAnalysis;

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
    public class SymbolSequencePoint :
        IComparable<SymbolSequencePoint>, IEquatable<SymbolSequencePoint>
    {
        /// <summary>
        ///   Gets a symbol meaning that the associated instructions have no source code.
        /// </summary>
        [SuppressMessage( "Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes" )]
        public static readonly SymbolSequencePoint Hidden = null;

        /// <summary>
        ///   Determines whether the current symbol means that the associated
        ///   instructions have no source code.
        /// </summary>
        public bool IsHidden { get; }

        /// <summary>
        /// Determines whether the current symbol is a special, non-standard, defined
        /// by PostSharp and supported by PostSharp Tools for Visual Studio.
        /// </summary>
        public bool IsSpecial { get; }

        /// <summary>
        ///   Gets the start line in the source file.
        /// </summary>
        public int StartLine { get; }

        /// <summary>
        ///   Gets the end line in the source file.
        /// </summary>
        public int EndLine { get; }

        /// <summary>
        ///   Gets the start column in the source file.
        /// </summary>
        public int StartColumn { get; }

        /// <summary>
        ///   Gets the end column in the source file.
        /// </summary>
        public int EndColumn { get; }

        /// <summary>
        ///   Gets the offset in the IL method body.
        /// </summary>
        internal int Offset { get; }

        /// <summary>
        /// Document (file of source code) containing the current sequence point.
        /// </summary>
        public ISourceDocument SourceDocument { get; }

        /// <inheritdoc />
        public int CompareTo( SymbolSequencePoint other )
        {
            throw new NotImplementedException();
        }

        #region IEquatable<SymbolSequencePoint> Members

        /// <inheritdoc />
        public bool Equals( SymbolSequencePoint other )
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override bool Equals( object obj )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Determines whether two sequence points are equal.
        /// </summary>
        /// <param name = "left">A <see cref = "SymbolSequencePoint" />.</param>
        /// <param name = "right">A <see cref = "SymbolSequencePoint" />.</param>
        /// <returns><c>true</c> if both sequence points are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///   Determines whether two sequence points are different.
        /// </summary>
        /// <param name = "left">A <see cref = "SymbolSequencePoint" />.</param>
        /// <param name = "right">A <see cref = "SymbolSequencePoint" />.</param>
        /// <returns><c>true</c> if both sequence points are different, otherwise <c>false</c>.</returns>
        public static bool operator !=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            return ReferenceEquals( left, null ) ? !ReferenceEquals( right, null ) : left.CompareTo( right ) < 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator <=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            return ReferenceEquals( left, null ) || left.CompareTo( right ) <= 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            return !ReferenceEquals( left, null ) && left.CompareTo( right ) > 0;
        }

        /// <summary>
        /// Operator.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator >=( SymbolSequencePoint left, SymbolSequencePoint right )
        {
            return ReferenceEquals( left, null ) ? ReferenceEquals( right, null ) : left.CompareTo( right ) >= 0;
        }

        #endregion
    }
}
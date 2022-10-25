using System;
using System.Reflection;
using PostSharp.Reflection;
using PostSharp.Reflection.MethodBody;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Represents the location of a message, which means, for the end-user, a line in a file of source code.
    /// From the aspect developer, the location can be known as an object representing an element of code
    /// (for instance a <see cref="Type"/> or <see cref="MethodInfo"/>). Such implicit locations are resolved
    /// by PostSharp to a file and line number.
    /// </summary>
    [Serializable]
    public class MessageLocation
    {
        [NonSerialized]
#pragma warning disable 649

        /// <summary>
        /// Represents an unknown or indeterminate location of the error message.
        /// </summary>
        public static readonly MessageLocation Unknown;
#pragma warning restore 649

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from a <see cref="SymbolSequencePoint"/>.
        /// </summary>
        /// <param name="symbolSequencePoint">A <see cref="SymbolSequencePoint"/>.</param>
        /// <returns>A <see cref="MessageLocation"/> corresponding to <paramref name="symbolSequencePoint"/>.</returns>
        public static MessageLocation Of( SymbolSequencePoint symbolSequencePoint )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> explicitly by specifying a filename, line, and column.
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="lineStart">Starting line number.</param>
        /// <param name="columnStart">Starting column number.</param>
        /// <param name="lineEnd">Ending line number.</param>
        /// <param name="columnEnd">Ending column number.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Explicit( string file, int lineStart, int columnStart, int lineEnd, int columnEnd )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> explicitly by specifying a filename, line, and column.
        /// </summary>
        /// <param name="file">File name.</param>
        /// <param name="line">Line number.</param>
        /// <param name="column">Column number.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Explicit( string file, int line, int column )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> explicitly by specifying a filename, when the
        /// </summary>
        /// <param name="file">File name.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Explicit( string file )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from an object representing an
        /// element of code (<see cref="Type"/>, <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>,
        /// <see cref="FieldInfo"/>, <see cref="IExpression"/>, <see cref="Assembly"/>, <see cref="ParameterInfo"/>, <see cref="EventInfo"/>,
        /// <see cref="PropertyInfo"/> or, if
        /// you are using PostSharp SDK, any <c>Declaration</c>).
        /// </summary>
        /// <param name="codeElement">an object representing an
        /// element of code (<see cref="Type"/>, <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>,
        /// <see cref="FieldInfo"/>, <see cref="Assembly"/>, <see cref="ParameterInfo"/>, <see cref="EventInfo"/>,
        /// <see cref="PropertyInfo"/>, <see cref="IExpression"/> or, if you are using PostSharp SDK, any <c>Declaration</c>.</param>
        /// <returns>A <see cref="MessageLocation"/> representing <paramref name="codeElement"/>.</returns>
        /// <remarks>
        ///     <para>If <paramref name="codeElement"/> is <c>null</c> or cannot mapped to a location of code,
        /// this method silently returns <see cref="Unknown"/>.</para>
        /// </remarks>
        public static MessageLocation Of( object codeElement )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from a <see cref="MemberInfo"/> (<see cref="Type"/>, 
        /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="FieldInfo"/>,
        /// <see cref="PropertyInfo"/>, <see cref="EventInfo"/>).
        /// </summary>
        /// <param name="member">An element of code (<see cref="Type"/>, 
        /// <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>, <see cref="FieldInfo"/>,
        /// <see cref="PropertyInfo"/>, <see cref="EventInfo"/>).</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Of( MemberInfo member )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from a <see cref="ParameterInfo"/>.
        /// </summary>
        /// <param name="parameter">A <see cref="ParameterInfo"/>.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Of( ParameterInfo parameter )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from a <see cref="LocationInfo"/>.
        /// </summary>
        /// <param name="location">A <see cref="LocationInfo"/>.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Of( LocationInfo location )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from an <see cref="Assembly"/>.
        /// </summary>
        /// <param name="assembly">An <see cref="Assembly"/> (<see cref="Assembly"/> or its wrapper).</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Of( Assembly assembly )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Builds a <see cref="MessageLocation"/> from an <see cref="IExpression"/>.
        /// </summary>
        /// <param name="expression">An <see cref="IExpression"/>.</param>
        /// <returns>A <see cref="MessageLocation"/>.</returns>
        public static MessageLocation Of( IExpression expression )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Element of code (reflection object or <c>Declaration</c>) from which the location must be resolved.
        /// </summary>
        public object CodeElement { get; }

        /// <summary>
        ///   Gets the name of the file that caused the message.
        /// </summary>
        /// <value>
        ///   Absolute path to the file or <c>null</c> if the file name
        ///   is unknown or not applicable.
        /// </value>
        public string File { get; }

        /// <summary>
        ///   Gets the starting line in the file that caused the message.
        /// </summary>
        /// <summary>
        ///   An integer greater or equal to 1, or 0
        ///   if the line is unknown or does not apply.
        /// </summary>
        public int StartLine { get; }

        /// <summary>
        ///   Gets the starting column in the file that caused the message.
        /// </summary>
        /// <summary>
        ///   An integer greater or equal to 1, or 0
        ///   if the column is unknown or does not apply.
        /// </summary>
        public int StartColumn { get; }

        /// <summary>
        ///   Gets the ending line in the file that caused the message.
        /// </summary>
        /// <summary>
        ///   An integer greater or equal to 1, or 0
        ///   if the line is unknown or does not apply.
        /// </summary>
        public int EndLine { get; }

        /// <summary>
        ///   Gets the ending column in the file that caused the
        ///   message.
        /// </summary>
        /// <summary>
        ///   An integer greater or equal to 1, or 0
        ///   if the column is unknown or does not apply.
        /// </summary>
        public int EndColumn { get; }
    }
}
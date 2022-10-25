using System;
using System.Reflection;
using PostSharp.Reflection;

namespace PostSharp.Extensibility
{
    /// <summary>
    /// Provides a method that returns the file and line where a declaration (such as a <see cref="Type"/> or <see cref="MethodInfo"/>) is declared.
    /// </summary>
    public interface IMessageLocationResolver : IService
    {
        /// <summary>
        ///  Gets the file and line where a declaration is declared.
        /// </summary>
        /// <param name="codeElement">A <see cref="MemberInfo"/>, <see cref="Type"/>, <see cref="ParameterInfo"/> or <see cref="LocationInfo"/>. </param>
        /// <returns>A <see cref="MessageLocation"/> describing where <paramref name="codeElement"/> is declared, or <see cref="MessageLocation.Unknown"/>
        /// if the location cannot be determined.</returns>
        MessageLocation GetMessageLocation( object codeElement );
    }
}
using System;
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that depends on a metadata declaration. This expression
    /// is used when compiling the <c>typeof</c>, <c>sizeof</c> or <c>default</c> keywords of C#, among others.
    /// </summary>
    public interface IMetadataExpression : IExpression
    {
        /// <summary>
        /// Gets the declaration (<see cref="Type"/>, <see cref="FieldInfo"/>, <see cref="MethodInfo"/>, <see cref="ConstructorInfo"/>).
        /// </summary>
        MemberInfo Declaration { get; }
    }
}
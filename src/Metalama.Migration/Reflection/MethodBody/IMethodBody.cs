using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Represents the body of a method.
    /// </summary>
    public interface IMethodBody : IMethodBodyElement
    {
        /// <summary>
        /// Gets the method whose body is represented by the current object.
        /// </summary>
        MethodBase Method { get; }

        /// <summary>
        /// Gets the root instruction block of the method.
        /// </summary>
        IBlockExpression RootBlock { get; }
    }
}
using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    /// <summary>
    /// Expression that represents a method parameter.
    /// </summary>
    public interface IParameterExpression : IExpression
    {
        /// <summary>
        /// Gets the parameter.
        /// </summary>
        ParameterInfo Parameter { get; }
    }
}
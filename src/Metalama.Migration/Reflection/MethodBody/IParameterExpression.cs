using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IParameterExpression : IExpression
    {
        ParameterInfo Parameter { get; }
    }
}
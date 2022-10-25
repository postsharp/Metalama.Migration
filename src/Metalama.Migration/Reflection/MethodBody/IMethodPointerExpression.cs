using System.Reflection;

namespace PostSharp.Reflection.MethodBody
{
    public interface IMethodPointerExpression : IExpression
    {
        IExpression Instance { get; }

        MethodBase Method { get; }
    }
}
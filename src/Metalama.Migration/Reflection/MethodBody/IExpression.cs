using System;

namespace PostSharp.Reflection.MethodBody
{
    public interface IExpression : IMethodBodyElement
    {
        Type ReturnType { get; }

        //SyntaxLocation Location { get; }
    }
}
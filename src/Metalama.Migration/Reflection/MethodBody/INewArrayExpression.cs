using System;

namespace PostSharp.Reflection.MethodBody
{
    public interface INewArrayExpression : IExpression
    {
        IExpression Length { get; }

        Type ElementType { get; }
    }
}
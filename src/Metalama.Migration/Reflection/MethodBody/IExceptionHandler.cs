using System;

namespace PostSharp.Reflection.MethodBody
{
    public interface IExceptionHandler
    {
        Type ExceptionType { get; }

        IBlockExpression TryBlock { get; }

        IBlockExpression FilterBlock { get; }

        IBlockExpression HandlerBlock { get; }

        ILocalVariable HandlerLocalVariable { get; }

        ILocalVariable FilterLocalVariable { get; }

        ExceptionHandlerKind ExceptionHandlerKind { get; }
    }
}